using Microsoft.AspNetCore.Mvc;
using SPR311_DreamTeam_Rozetka.BLL.DTOs.User;
using SPR311_DreamTeam_Rozetka.BLL.Services.User;
using SPR311_DreamTeam_Rozetka.BLL.Validators.User;

namespace SPR311_DreamTeam_Rozetka.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly CreateValidator _createValidator;
        private readonly UpdateValidator _updateValidator;

        public UserController(IUserService userService, CreateValidator createValidator, UpdateValidator updateValidator)
        {
            _userService = userService;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateUserDTO dto)
        {
            var validResult = await _createValidator.ValidateAsync(dto);

            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors);
            }

            var response = await _userService.CreateAsync(dto);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateUserDTO dto)
        {
            var validResult = await _updateValidator.ValidateAsync(dto);

            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors);
            }

            var response = await _userService.UpdateAsync(dto);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("id is required!");
            }

            var response = await _userService.DeleteAsync(id);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("id is required!");
            }

            var response = await _userService.GetByIdAsync(id);
            return response?.IsSuccess == true ? Ok(response) : BadRequest(response);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _userService.GetAllAsync();
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}
