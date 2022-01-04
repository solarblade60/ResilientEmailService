
using Newtonsoft.Json;

namespace RupaHealth.Models.Dtos
{
    public class SendGridEmailRequest
    {
        [JsonProperty(PropertyName = "Personalizations")]
        public PersonalizationDto[] Personalizations { get; set; }

        [JsonProperty(PropertyName = "Content")]
        public ContentDto[] Content { get; set; }

        [JsonProperty(PropertyName = "From")]
        public EmailNameDto From { get; set; }

        [JsonProperty(PropertyName = "Reply_To")]
        public EmailNameDto Reply_To { get; set; }
    }
}
