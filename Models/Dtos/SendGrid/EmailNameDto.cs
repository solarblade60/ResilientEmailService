
using Newtonsoft.Json;

namespace RupaHealth.Models.Dtos
{
    public class EmailNameDto
    {
        [JsonProperty(PropertyName = "Email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
}
