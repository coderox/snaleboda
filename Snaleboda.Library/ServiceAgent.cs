using System;
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

        public async Task<IList<NewsModel>> GetNewsAsync()
        {
            IList<NewsModel> result;
            try
            {
                var client = new HttpClient();
                var uri = new Uri(NEWS_URL, UriKind.Absolute);
                var content = await client.GetStringAsync(uri);
                result = JsonConvert.DeserializeObject<IList<NewsModel>>(content);
            }
            catch (Exception ex)
            {
                result = new List<NewsModel>();
            }
            return result;
        }

        public async Task<IList<ContactModel>> GetContactsAsync()
        {
            IList<ContactModel> result;
            try
            {
                var client = new HttpClient();
                var uri = new Uri(CONTACTS_URL, UriKind.Absolute);
                var content = await client.GetStringAsync(uri);
                result = JsonConvert.DeserializeObject<IList<ContactModel>>(content);
            }
            catch (Exception ex)
            {
                result = new List<ContactModel>();
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
                var response = await client.PostAsync(uri, content);
                Debug.WriteLine(response.IsSuccessStatusCode);
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
