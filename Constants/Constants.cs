using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RupaHealth.Constants
{
    public static class EmailDeliveryUrls
    {
        public const string SendGridUrl = "https://api.sendgrid.com/v3/mail/send";
        public const string MailGunUrl = "https://api.mailgun.net/v3/sandbox2dccf6a0ccfa4c95bb6d9cd320375aa3.mailgun.org/messages";
    }

    public static class EmailDeliveryAPIKeys
    {
        public const string SendGridAPIKey = "SG.WG6S6NtzRyqHOmmSyFyKqw.ShYdtntljF7uXhkQQ0HWKszL0gs6rWn7YYqetQVPsRY";
        public const string MailGunAPIKey = "e5f8bc6502ebb89ca95f728541a0f77e-0be3b63b-ed90db63";
    }
}
