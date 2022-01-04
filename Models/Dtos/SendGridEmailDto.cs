
namespace RupaHealth.Models.Dtos
{
    public class SendGridEmailDto
    {
        public PersonalizationDto[] Personalizations { get; set; }
        public ContentDto[] Content { get; set; }
        public EmailDto From { get; set; }
        public EmailDto Reply_To { get; set; }
    }
}
