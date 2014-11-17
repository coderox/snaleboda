using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Snaleboda.Core.Interfaces;
using Snaleboda.Core.Models;

namespace Snaleboda.Core.Services
{
    public class AsyncServiceAgent : IAsyncServiceAgent
    {
        const string BASE_URL = "https://snaleboda.azure-mobile.net/tables/";
        const string NEWS_URL = BASE_URL + "news";
        const string CONTACTS_URL = BASE_URL + "contacts";
        const string INCIDENTS_URL = BASE_URL + "incidents";

        private readonly ISerializerProvider _serializer;

        public AsyncServiceAgent(ISerializerProvider serializer)
        {
            _serializer = serializer;
        }

        public Task<IList<News>> GetNewsAsync()
        {
            return Get<IList<News>>(NEWS_URL);
        }

        public Task<IList<Contact>> GetContactsAsync()
        {
            return Get<IList<Contact>>(CONTACTS_URL);
        }

        private async Task<T> Get<T>(string url)
        {
            T result;

            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(new Uri(new Uri(BASE_URL, UriKind.Absolute), url));
                var json = await response.Content.ReadAsStringAsync();
                result = _serializer.Deserialize<T>(json);
            }
            catch (Exception)
            {
                result = default(T);
            }
            return result;
        }

        public Task PostIncidentAsync(Incident incident)
        {
            throw new NotImplementedException();
        }
    }

    public class AsyncServiceAgentFake : IAsyncServiceAgent
    {
        #region Fake data
        private static List<News> _news = new List<News>
        {
            new News { Id = "1", Title = "Title 1", Content = "Content"},
            new News { Id = "2", Title = "Title 2", Content = "Content"},
            new News { Id = "3", Title = "Title 3", Content = "Content"},
            new News { Id = "4", Title = "Title 4", Content = "Content"},
            new News { Id = "5", Title = "Title 5", Content = "Content"},
        };

        private static List<Contact> _contacts = new List<Contact>()
        {
            new Contact {Id = "1", Name =  "Johan Lindfors", Email = "johan.lindfors@coderox.se", Phone = "+46734200271"},
        };
        #endregion

        public async Task<IList<News>> GetNewsAsync()
        {
            await Task.Delay(1000);
            return _news;
        }

        public async Task<IList<Contact>> GetContactsAsync()
        {
            await Task.Delay(1000);
            return _contacts;
        }

        public Task PostIncidentAsync(Incident incident)
        {
            throw new NotImplementedException();
        }
    }
}
