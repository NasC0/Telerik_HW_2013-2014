using Newtonsoft.Json;

namespace WriteTitlesToConsole
{
    public class RssEntry
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }
    }
}
