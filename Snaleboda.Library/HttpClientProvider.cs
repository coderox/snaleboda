using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Snaleboda.Library
{
    public interface IHttpClientProvider
    {
        Task<string> GetJsonAsync(Uri uri);
        Task PutJsonAsync(Uri uri, string json);
    }

    public class HttpClientProvider : IHttpClientProvider
    {
        public Task<string> GetJsonAsync(Uri uri)
        {
            var client = new HttpClient();
            return client.GetStringAsync(uri);
        }

        public Task PutJsonAsync(Uri uri, string json)
        {
            var client = new HttpClient();            
            var content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            content.Headers.Add("X-ZUMO-APPLICATION", APPLICATION_KEY);
            return client.PutAsync(uri, content);
        }

        #region SECRET STUFF HERE, NEVER TRUST THE AUDIENCE
        private const string APPLICATION_KEY = "RyRNAoNAhIIaDeboNqfwwdxJZSuQyi32";
        #endregion
    }

    public class FakeHttpClientProvider : IHttpClientProvider
    {
        public async Task<string> GetJsonAsync(Uri uri)
        {
            var segment = uri.Segments.Last();
            switch (segment)
            {
                case "news":
                    return @"[{""id"":""2DF24494-4315-4236-B480-0351F9D6F404"",""title"":""Visual Studio version 14"",""content"":""Nu har Xamarin 10 kommit.""}]";
                default:
                    return "[]";
            }
        }

        public Task PutJsonAsync(Uri uri, string json)
        {
            throw new NotImplementedException();
        }
    }
}
