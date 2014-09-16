using Newtonsoft.Json;
using Snaleboda.Library.Interfaces;

namespace Snaleboda.Utilities
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
