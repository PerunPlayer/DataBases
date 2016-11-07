using Newtonsoft.Json;

namespace JSONProcessing
{
    public class Link
    {
        [JsonProperty("@rel")]
        public string Rel { get; set; }

        [JsonProperty("@href")]
        public string Href { get; set; }
    }
}
