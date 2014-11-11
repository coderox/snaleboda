using Snaleboda.Xamarin.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Snaleboda.Xamarin.Core.Services
{
    public class IncidentService
    {
        public async Task PostIncidentAsync(Incident incident)
        {
            var url = "https://snaleboda.azure-mobile.net/tables/incidents";

            var client = new HttpClient();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(incident);
            await client.PostAsync(url, new StringContent(json));
        }
    }
}
