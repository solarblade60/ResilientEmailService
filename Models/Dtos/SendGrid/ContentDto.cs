
using Newtonsoft.Json;

namespace RupaHealth.Models.Dtos
{
    public class ContentDto
    {
        [JsonProperty(PropertyName = "Type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "Value")]
        public string Value { get; set; }
    }
}
