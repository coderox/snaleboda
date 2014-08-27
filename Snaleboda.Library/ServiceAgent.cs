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
        const string BASE_URL = "https://snaleboda.azure-mobile.net/tables/";
        const string NEWS_URL = BASE_URL + "news";
        const string CONTACTS_URL = BASE_URL + "contacts";
        const string INCIDENTS_URL = BASE_URL + "incidents";

        public Task<IList<NewsModel>> GetNewsAsync()
        {
            return GetAsync<IList<NewsModel>>(NEWS_URL);
        }

        public Task<IList<ContactModel>> GetContactsAsync()
        {
            return GetAsync<IList<ContactModel>>(CONTACTS_URL);            
        }

        private static async Task<T> GetAsync<T>(string url)
        {
            T result;
            try
            {
                var client = new HttpClient();
                var uri = new Uri(CONTACTS_URL, UriKind.Absolute);
                var content = await client.GetStringAsync(uri);
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
                var client = new HttpClient();
                var uri = new Uri(INCIDENTS_URL, UriKind.Absolute);
                var json = JsonConvert.SerializeObject(incident);
                var content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                content.Headers.Add("X-ZUMO-APPLICATION", APPLICATION_KEY);
                await client.PostAsync(uri, content);
            }
            catch
            {

            }
        }

        #region SECRET STUFF HERE, NEVER TRUST THE AUDIENCE
        private const string APPLICATION_KEY = "RyRNAoNAhIIaDeboNqfwwdxJZSuQyi32";
        #endregion
    }
}
