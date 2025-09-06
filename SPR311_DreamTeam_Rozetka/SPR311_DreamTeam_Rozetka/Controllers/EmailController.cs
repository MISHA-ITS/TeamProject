// SPR311_DreamTeam_Rozetka/Controllers/EmailController.cs
using Microsoft.AspNetCore.Mvc;
using SPR311_DreamTeam_Rozetka.BLL.Services.Email;

namespace SPR311_DreamTeam_Rozetka.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail(
            [FromBody] SendEmailRequest request)
        {
            try
            {
                var result = await _emailService.SendEmailAsync(
                    request.To,
                    request.Subject,
                    request.Body,
                    request.IsHtml
                );

                return Ok(new
                {
                    Success = result,
                    Message = result ? "Лист відправлено успішно" : "Помилка відправки листа"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Success = false,
                    Message = "Помилка відправки",
                    Error = ex.Message
                });
            }
        }

        [HttpPost("welcome")]
        public async Task<IActionResult> SendWelcomeEmail(
            [FromBody] WelcomeEmailRequest request)
        {
            try
            {
                var result = await _emailService.SendWelcomeEmailAsync(
                    request.To,
                    request.UserName
                );

                return Ok(new
                {
                    Success = result,
                    Message = result ? "Вітальний лист відправлено" : "Помилка відправки"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Success = false,
                    Message = "Помилка відправки",
                    Error = ex.Message
                });
            }
        }

        [HttpPost("password-reset")]
        public async Task<IActionResult> SendPasswordResetEmail(
            [FromBody] PasswordResetRequest request)
        {
            try
            {
                var result = await _emailService.SendPasswordResetAsync(
                    request.To,
                    request.ResetLink
                );

                return Ok(new
                {
                    Success = result,
                    Message = result ? "Лист для скидання пароля відправлено" : "Помилка відправки"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Success = false,
                    Message = "Помилка відправки листа для скидання пароля",
                    Error = ex.Message
                });
            }
        }

        [HttpPost("order-confirmation")]
        public async Task<IActionResult> SendOrderConfirmationEmail(
            [FromBody] OrderConfirmationRequest request)
        {
            try
            {
                var result = await _emailService.SendOrderConfirmationAsync(
                    request.To,
                    request.OrderId,
                    request.TotalAmount
                );

                return Ok(new
                {
                    Success = result,
                    Message = result ? "Лист підтвердження замовлення відправлено" : "Помилка відправки"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Success = false,
                    Message = "Помилка відправки листа підтвердження замовлення",
                    Error = ex.Message
                });
            }
        }
    }

    public class SendEmailRequest
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }
    }

    public class WelcomeEmailRequest
    {
        public string To { get; set; }
        public string UserName { get; set; }
    }

    public class PasswordResetRequest
    {
        public string To { get; set; }
        public string ResetLink { get; set; }
    }

    public class OrderConfirmationRequest
    {
        public string To { get; set; }
        public string OrderId { get; set; }
        public decimal TotalAmount { get; set; }
    }
}