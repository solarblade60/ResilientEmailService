using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RupaHealth.Constants;
using RupaHealth.Helpers;
using RupaHealth.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RupaHealth
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        private readonly ILogger _logger;

        public EmailService(IConfiguration config, ILogger<EmailService> logger)
        {
            _config = config;
            _logger = logger;
        }

        public async Task<bool> ResilientEmailDeliveryService(EmailDto data)
        {
            var isSendGridEmailDeliverySuccess = await SendEmailViaSendGrid(data);

            if (!isSendGridEmailDeliverySuccess)
            {
                return await SendEmailViaMailGun(data);
            }
            else
            {
                return true;
            }
        }

        private async Task<bool> SendEmailViaSendGrid(EmailDto emailData)
        {
            bool isSuccess = false;

            try
            {
                var request = CreateSendGridEmailRequest(emailData);

                using var client = new HttpClient();

                var response = await client.SendAsync(request);
            }
            catch (Exception e)
            {
                _logger.LogError("Error sending email via SendGrid", e);

                throw;
            }

            return isSuccess;
        }

        private async Task<bool> SendEmailViaMailGun(EmailDto emailData)
        {
            bool isSuccess = false;

            try
            {
                var request = CreateMailGunEmailRequest(emailData);

                using var client = new HttpClient();

                var response = await client.SendAsync(request);

                isSuccess = response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                _logger.LogError("Error sending email via MailGun", e);

                throw;
            }

            return isSuccess;
        }

        private HttpRequestMessage CreateSendGridEmailRequest(EmailDto emailData)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, EmailDeliveryUrls.SendGridUrl);

            //Authorization

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", EmailDeliveryAPIKeys.SendGridAPIKey);

            //Content

            SendGridEmailRequest sendGridRequest = new SendGridEmailRequest();

            var personalization = new PersonalizationDto();

            personalization.Subject = emailData.Subject;

            var to = new EmailNameDto();
            to.Email = emailData.ToEmailAddress;
            to.Name = emailData.ToName;

            personalization.To = new EmailNameDto[] { to };
            sendGridRequest.Personalizations = new PersonalizationDto[] { personalization };

            var content = new ContentDto();
            content.Type = "text/plain";
            content.Value = StringHelper.ConvertHTMLStringToPlainText(emailData.Body);

            sendGridRequest.Content = new ContentDto[] { content };

            var from = new EmailNameDto();
            from.Email = emailData.FromEmailAddress;
            from.Name = emailData.FromName;

            sendGridRequest.From = from;
            sendGridRequest.Reply_To = from;

            var jsonContent = JsonConvert.SerializeObject(sendGridRequest);
            var contentData = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            request.Content = contentData;
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return request;
        }

        private HttpRequestMessage CreateMailGunEmailRequest(EmailDto emailData)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, EmailDeliveryUrls.MailGunUrl);

            //Authorization

            var authenticationString = $"api:{EmailDeliveryAPIKeys.MailGunAPIKey}";
            var base64EncodedAuthenticationString = Convert.ToBase64String(Encoding.ASCII.GetBytes(authenticationString));

            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);

            //Content

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("from", emailData.FromEmailAddress),
                new KeyValuePair<string, string>("to", emailData.ToEmailAddress),
                new KeyValuePair<string, string>("subject", emailData.Subject),
                new KeyValuePair<string, string>("text", StringHelper.ConvertHTMLStringToPlainText(emailData.Body))
            });

            request.Content = content;

            return request;
        }
    }
}
