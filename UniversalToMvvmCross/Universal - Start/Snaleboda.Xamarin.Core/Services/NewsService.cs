using Snaleboda.Xamarin.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Snaleboda.Xamarin.Core.Services
{

    // CREATE SNIPPET 1

    public class NewsService
    {
        public async Task<List<News>> GetNewsAsync()
        {
            var url = "https://snaleboda.azure-mobile.net/tables/news";

            var client = new HttpClient();
            var json = await client.GetStringAsync(url);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<News>>(json);

            return result;
        }
    }
}
