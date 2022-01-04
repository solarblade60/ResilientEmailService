
using Newtonsoft.Json;

namespace RupaHealth.Models.Dtos
{
    public class PersonalizationDto
    {
        [JsonProperty(PropertyName = "To")]
        public EmailNameDto[] To { get; set; }

        [JsonProperty(PropertyName = "Subject")]
        public string Subject { get; set; }
    }
}
