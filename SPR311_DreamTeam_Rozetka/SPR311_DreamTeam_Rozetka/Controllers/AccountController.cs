using Microsoft.AspNetCore.Mvc;
using SPR311_DreamTeam_Rozetka.BLL.DTOs.Account;
using SPR311_DreamTeam_Rozetka.BLL.Services.Account;
using SPR311_DreamTeam_Rozetka.BLL.Validators.Account;

namespace SPR311_DreamTeam_Rozetka.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly RegisterValdator _registerValidator;
        private readonly LoginValidator _loginValidator;

        public AccountController(IAccountService accountService, RegisterValdator registerValidator, LoginValidator loginValidator)
        {
            _accountService = accountService;
            _registerValidator = registerValidator;
            _loginValidator = loginValidator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterDTO dto)
        {
            var validResult = await _registerValidator.ValidateAsync(dto);

            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors);
            }

            var user = await _accountService.RegisterAsync(dto);

            if (user == null || user?.PayLoad == null)
            {
                return BadRequest("Register error");
            }

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginDTO dto)
        {
            var validResult = await _loginValidator.ValidateAsync(dto);

            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors);
            }

            var response = await _accountService.LoginAsync(dto);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLoginAsync([FromForm] GoogleLoginDTO dto)
        {
            var response = await _accountService.GoogleLoginAsync(dto);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}
