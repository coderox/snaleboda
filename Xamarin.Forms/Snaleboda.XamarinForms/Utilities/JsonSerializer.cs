using Newtonsoft.Json;
using Snaleboda.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snaleboda.XamarinForms.Utilities
{
    public class JsonSerializer : ISerializer
    {
        public T Deserialize<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }

        public string Serialize(object content)
        {
            return JsonConvert.SerializeObject(content);
        }
    }
}
