using Newtonsoft.Json;

namespace JsonParser.Models
{
    public class Address
    {
        [JsonProperty("street")]

        public string? Street { get;  set; }
        [JsonProperty("city")]
        public string? City { get;  set; }
        [JsonProperty("state")]
        public string? State { get;  set; }
        [JsonProperty("zip")]
        public string? ZipCode { get;  set; }
    }
}