using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;

namespace SPR311_DreamTeam_Rozetka.BLL.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<bool> SendEmailAsync(string to, string subject, string body, bool isHtml = false)
        {
            try
            {
                var smtpServer = _configuration["Email:SmtpServer"] ?? "smtp.gmail.com";
                var port = int.Parse(_configuration["Email:Port"] ?? "587");
                var username = _configuration["Email:Username"];
                var password = _configuration["Email:Password"];
                var fromAddress = _configuration["Email:FromAddress"] ?? "noreply@rozetka-clone.com";
                var fromName = _configuration["Email:FromName"] ?? "Rozetka Clone";

                using (var client = new SmtpClient(smtpServer, port))
                {
                    client.Credentials = new NetworkCredential(username, password);
                    client.EnableSsl = true;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(fromAddress, fromName),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = isHtml
                    };
                    mailMessage.To.Add(to);

                    await client.SendMailAsync(mailMessage);
                    _logger.LogInformation($"Email sent successfully to {to}");
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to send email to {to}");
                return false;
            }
        }

        public async Task<bool> SendOrderConfirmationAsync(string to, string orderId, decimal totalAmount)
        {
            var subject = "Підтвердження замовлення";
            var body = $@"
                <h1>Дякуємо за ваше замовлення!</h1>
                <p>Номер замовлення: {orderId}</p>
                <p>Загальна сума: {totalAmount} грн</p>
                <p>Дата замовлення: {DateTime.Now:dd.MM.yyyy HH:mm}</p>
            ";

            return await SendEmailAsync(to, subject, body, true);
        }

        public async Task<bool> SendPasswordResetAsync(string to, string resetLink)
        {
            var subject = "Відновлення пароля";
            var body = $@"
                <h1>Відновлення пароля</h1>
                <p>Для відновлення пароля перейдіть за посиланням:</p>
                <p><a href='{resetLink}'>Відновити пароль</a></p>
                <p>Якщо ви не запитували відновлення пароля, проігноруйте цей лист.</p>
            ";

            return await SendEmailAsync(to, subject, body, true);
        }

        public async Task<bool> SendWelcomeEmailAsync(string to, string userName)
        {
            var subject = "Ласкаво просимо до Rozetka Clone!";
            var body = $@"
                <h1>Вітаємо, {userName}!</h1>
                <p>Дякуємо за реєстрацію в нашому магазині.</p>
                <p>Тепер ви можете робити покупки та отримувати спеціальні пропозиції.</p>
            ";

            return await SendEmailAsync(to, subject, body, true);
        }
    }
}