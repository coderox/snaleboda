﻿using Newtonsoft.Json;
using Snaleboda.Library.Interfaces;
using Snaleboda.Library.Models;
using Snaleboda.Library.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snaleboda.Library.Services
{
    public class AsyncServiceAgent : IAsyncServiceAgent
    {
        private readonly IHttpClientProvider _client;

        const string BASE_URL = "https://snaleboda.azure-mobile.net/tables/";
        const string NEWS_URL = BASE_URL + "news";
        const string CONTACTS_URL = BASE_URL + "contacts";
        const string INCIDENTS_URL = BASE_URL + "incidents";

        public AsyncServiceAgent() : this(new HttpClientProvider())
        {
            
        }

        public AsyncServiceAgent(IHttpClientProvider clientProvider)
        {
            _client = clientProvider;
        }

 
        public Task<IList<NewsModel>> GetNewsAsync()
        {
            return GetAsync<IList<NewsModel>>(NEWS_URL);
        }

        public Task<IList<ContactModel>> GetContactsAsync()
        {
            return GetAsync<IList<ContactModel>>(CONTACTS_URL);            
        }

        private async Task<T> GetAsync<T>(string url)
        {
            T result;
            try
            {  
                var uri = new Uri(url, UriKind.Absolute);
                var content = await _client.GetJsonAsync(uri).ConfigureAwait(false);
                
                result = JsonConvert.DeserializeObject<T>(content);
            }
            catch (Exception ex)
            {
                result = default(T);
            }
            return result;
        }

        public async Task PostIncidentAsync(IncidentModel incident)
        {
            try
            {                
                var uri = new Uri(INCIDENTS_URL, UriKind.Absolute);
                var json = JsonConvert.SerializeObject(incident);
                
                await _client.PutJsonAsync(uri, json).ConfigureAwait(false);
            }
            catch
            {

            }
        }
    }

    public class FakeAsyncServiceAgent : IAsyncServiceAgent
    {
        #region Static data
        private static List<NewsModel> _news  = new List<NewsModel>
        {
            new NewsModel {Title = "News Item 1", Content = "Content"},
            new NewsModel {Title = "News Item 2", Content = "Content"},
            new NewsModel {Title = "News Item 3", Content = "Content"},
            new NewsModel {Title = "News Item 4", Content = "Content"},
            new NewsModel {Title = "News Item 5", Content = "Content"},
        };

        private static List<ContactModel> _contacts = new List<ContactModel>
        {
            new ContactModel { Name = "Johan Lindfors", Email = "johan.lindfors@coderox.se", Phone = "1234567890"},
        };
        #endregion

        #region IAsyncServiceAgent
        public async Task<IList<NewsModel>> GetNewsAsync()
        {
            await Task.Delay(1500);
            return _news;
        }

        public async Task<IList<ContactModel>> GetContactsAsync()
        {
            await Task.Delay(1500); 
            return _contacts;
        }

        public Task PostIncidentAsync(IncidentModel incident)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}