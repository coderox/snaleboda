using Newtonsoft.Json;

namespace Snaleboda.Library
{
    public partial class IncidentModel
    {
        //public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }
    }
}
