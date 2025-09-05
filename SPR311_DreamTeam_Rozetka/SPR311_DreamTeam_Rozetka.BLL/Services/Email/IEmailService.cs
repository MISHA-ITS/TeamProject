namespace SPR311_DreamTeam_Rozetka.BLL.Services.Email
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string to, string subject, string body, bool isHtml = false);
        Task<bool> SendOrderConfirmationAsync(string to, string orderId, decimal totalAmount);
        Task<bool> SendPasswordResetAsync(string to, string resetLink);
        Task<bool> SendWelcomeEmailAsync(string to, string userName);
    }
}