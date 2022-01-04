

namespace RupaHealth.Models.Dtos
{
    public class EmailDto
    {
        public string ToEmailAddress { get; set; }
        public string ToName { get; set; }
        public string FromEmailAddress { get; set; }
        public string FromName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
