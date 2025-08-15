using Microsoft.Extensions.Options;
using RamMotorsWebApp.Models;
using System.Net;
using System.Net.Mail;

namespace RamMotorsWebApp.Services
{
    public class MailService
    {
        private readonly SmtpSettings _settings;

        public MailService(IOptions<SmtpSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendRequestDetailsEmailAsync(string name, string phone, string email, string message, string carTitle)
        {
            using (var client = new SmtpClient(_settings.Host, _settings.Port))
            {
                client.Credentials = new NetworkCredential(_settings.UserName, _settings.Password);
                client.EnableSsl = _settings.EnableSSL;

                var mail = new MailMessage
                {
                    From = new MailAddress(_settings.From, "Ram Motors Website"),
                    Subject = $"New Car Inquiry - {carTitle}",
                    Body = $@"
                    A new customer has requested details for a car.

                    Car: {carTitle}
                    Name: {name}
                    Phone: {phone}
                    Email: {email}

                    Message:
                    {message}

                    Please contact the customer as soon as possible.",
                    IsBodyHtml = false
                };

                mail.To.Add(_settings.To);

                await client.SendMailAsync(mail);
            }
        }

        public async Task SendDetailsEmailAsync(string name, string phone, string email, string message, string serviceName)
        {
            using (var client = new SmtpClient(_settings.Host, _settings.Port))
            {
                client.Credentials = new NetworkCredential(_settings.UserName, _settings.Password);
                client.EnableSsl = _settings.EnableSSL;

                var mail = new MailMessage
                {
                    From = new MailAddress(_settings.From, "Ram Motors Website"),
                    Subject = serviceName,
                    Body = $@"
                    A new customer has requested details for a {serviceName}.

                    Name: {name}
                    Phone: {phone}
                    Email: {email}

                    Message:
                    {message}

                    Please contact the customer as soon as possible.",
                    IsBodyHtml = false
                };

                mail.To.Add(_settings.To);

                await client.SendMailAsync(mail);
            }
        }
    }
}
