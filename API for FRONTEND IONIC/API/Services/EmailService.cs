using Microsoft.AspNet.Identity;
using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AspNetIdentity3.Services
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await configSendGridasync(message);
        }

        // Use NuGet to install SendGrid (Basic C# client lib) 
        private async Task configSendGridasync(IdentityMessage message)
        {
            Environment.SetEnvironmentVariable("SENDGRID_API_KEY", "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");
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);

            var msg = new SendGridMessage()
            {
                From = new EmailAddress("andreajaninaescobar@gmail.com", "Andrea Escobar"),
                Subject = message.Subject,
                PlainTextContent = message.Body,
                HtmlContent = message.Body
            };
            msg.AddTo(message.Destination);
            var response = await client.SendEmailAsync(msg);

            Console.WriteLine(response.StatusCode);
        }
    }
}