using Newtonsoft.Json;

namespace Snaleboda.Library.Models
{
    public partial class NewsModel
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }
    }
}
