using Diploma.Application.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Diploma.EmailSender
{
    public class MailSender : IMailSender
    {
        private readonly EmailServiceOptions _options;
        private readonly ILogger _logger;
        public MailSender(IOptions<EmailServiceOptions> options, ILogger<MailSender> logger)
        {
            _options = options.Value;
            _logger = logger;
        }

        /// <summary>
        ///     Отправка письма
        /// </summary>
        /// <param name="emailTo">email получателя</param>
        /// <param name="subject">тема письма</param>
        /// <param name="body">текст письма</param>
        public async Task SendEmailAsync(string emailTo, string subject, string body)
        {
            try
            {
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress("", _options.SenderLogin));
                emailMessage.To.Add(new MailboxAddress("", emailTo));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = body
                };
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_options.Host, _options.Port, _options.UseSsl);
                    await client.AuthenticateAsync(_options.SenderLogin, _options.SenderPassword);
                    await client.SendAsync(emailMessage);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
        }
    }
}
