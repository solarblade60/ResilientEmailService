using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RupaHealth.Models.Dtos;
using RupaHealth.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RupaHealth
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public async Task<bool> HandleEmail(EmailParams data)
        {
            var isSendGridSuccess = await SendEmailViaSendGrid(data);

            if (!isSendGridSuccess)
            {
                return await SendEmailViaMailGun(data);
            }
            else
            {
                return true;
            }
        }

        private async Task<bool> SendEmailViaSendGrid(EmailParams emailData)
        {
            var toEmailAddress = emailData.To;
            var toName = emailData.To_Name;
            var fromEmailAddress = emailData.From;
            var fromName = emailData.From_Name;
            var subject = emailData.Subject;
            var htmlContent = HttpUtility.HtmlEncode(emailData.Body);//TODO

            SendGridEmailDto sendGridMessage = new SendGridEmailDto();

            var personalization = new PersonalizationDto();
            personalization.Subject = subject;
            var to = new EmailDto();
            to.Email = toEmailAddress;
            to.Name = toName;
            personalization.To = new EmailDto[] { to };
            sendGridMessage.Personalizations = new PersonalizationDto[] { personalization };

            var content = new ContentDto();
            content.Type = "text/plain";
            content.Value = emailData.Body;

            sendGridMessage.Content = new ContentDto[] { content };
            var from = new EmailDto();
            from.Email = fromEmailAddress;
            from.Name = fromName;

            sendGridMessage.From = from;
            sendGridMessage.Reply_To = from;

            var json = JsonConvert.SerializeObject(sendGridMessage);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var sendGridUrl = "https://api.sendgrid.com/v3/mail/send";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, sendGridUrl);

            request.Content = data;
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "SG.WG6S6NtzRyqHOmmSyFyKqw.ShYdtntljF7uXhkQQ0HWKszL0gs6rWn7YYqetQVPsRY");

            var response = await client.SendAsync(request);

            return false;
        }

        private async Task<bool> SendEmailViaMailGun(EmailParams emailData)
        {
            return false;
        }
    }
}
