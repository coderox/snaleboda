using Snaleboda.Xamarin.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Snaleboda.Xamarin.Core.Services
{
    public class ContactService
    {
        public async Task<List<Contact>> GetContactsAsync()
        {
            var url = "https://snaleboda.azure-mobile.net/tables/contacts";

            var client = new HttpClient();
            var json = await client.GetStringAsync(url);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Contact>>(json);

            return result;
        }
    }
}
