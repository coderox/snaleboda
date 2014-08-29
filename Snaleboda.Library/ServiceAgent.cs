using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Snaleboda.Library
{
    public interface IServiceAgent
    {
        Task<IList<NewsModel>> GetNewsAsync();
        Task<IList<ContactModel>> GetContactsAsync();
        Task PostIncidentAsync(IncidentModel incident);
    }

    public class ServiceAgent : IServiceAgent
    {
        private readonly IHttpClientProvider _client;

        const string BASE_URL = "https://snaleboda.azure-mobile.net/tables/";
        const string NEWS_URL = BASE_URL + "news";
        const string CONTACTS_URL = BASE_URL + "contacts";
        const string INCIDENTS_URL = BASE_URL + "incidents";

        public ServiceAgent() : this(new HttpClientProvider())
        {
            
        }

        public ServiceAgent(IHttpClientProvider clientProvider)
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
                var content = await _client.GetJsonAsync(uri);
                
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
                
                await _client.PutJsonAsync(uri, json);
            }
            catch
            {

            }
        }
    }

    public class FakeServiceAgent : IServiceAgent
    {

        public async Task<IList<NewsModel>> GetNewsAsync()
        {
            var news = new List<NewsModel>
            {
                new NewsModel {Title = "News Item 1", Content = "Content"},
                new NewsModel {Title = "News Item 2", Content = "Content"},
                new NewsModel {Title = "News Item 3", Content = "Content"},
                new NewsModel {Title = "News Item 4", Content = "Content"},
                new NewsModel {Title = "News Item 5", Content = "Content"},
            };
            await Task.Delay(1500);
            return news;
        }

        public async Task<IList<ContactModel>> GetContactsAsync()
        {
            return new List<ContactModel>();
        }

        public Task PostIncidentAsync(IncidentModel incident)
        {
            throw new NotImplementedException();
        }
    }
}
