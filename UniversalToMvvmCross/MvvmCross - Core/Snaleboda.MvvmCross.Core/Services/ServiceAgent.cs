using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Snaleboda.Library.Interfaces;
using Snaleboda.Library.Models;

namespace Snaleboda.Library.Services
{
    public class ServiceAgent : IServiceAgent
    {
        private readonly IHttpClientProvider _client;
        private readonly ISerializer _serializer;

        const string BASE_URL = "https://snaleboda.azure-mobile.net/tables/";
        const string NEWS_URL = BASE_URL + "news";
        const string CONTACTS_URL = BASE_URL + "contacts";
        const string INCIDENTS_URL = BASE_URL + "incidents";

        public ServiceAgent(IHttpClientProvider clientProvider)
        {
            _client = clientProvider;
        }

        #region IServiceAgent
        public void GetNews(Action<IList<NewsModel>> callback)
        {
            //var result = await GetNewsAsync();
            //callback(result);
        }

        public void GetContacts(Action<IList<ContactModel>> callback)
        {
            //var result = await GetContactsAsync();
            //callback(result);
        }        

        public void PostIncident(IncidentModel incident)
        {
            //PostIncidentAsync(incident).Start();
        }
        #endregion
    }

    public class FakeServiceAgent : IServiceAgent
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

        #region IServiceAgent
        public async void GetNews(Action<IList<NewsModel>> callback)
        {
            await Task.Delay(1000).ConfigureAwait(false);
            callback(_news);
        }

        public async void GetContacts(Action<IList<ContactModel>> callback)
        {
            await Task.Delay(4000).ConfigureAwait(false);
            callback(_contacts);
        }

        public void PostIncident(IncidentModel incident)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
