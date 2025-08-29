using Microsoft.AspNetCore.Mvc;
using SPR311_DreamTeam_Rozetka.BLL.DTOs.Role;
using SPR311_DreamTeam_Rozetka.BLL.Services.Role;
using SPR311_DreamTeam_Rozetka.BLL.Validators.Role;

namespace SPR311_DreamTeam_Rozetka.Controllers
{
    [ApiController]
    [Route("api/role")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly CreateValidator _createValidator;
        private readonly UpdateValidator _updateValidator;
        private readonly ILogger<RoleController> _logger;

        public RoleController(IRoleService roleService, CreateValidator createValidator, UpdateValidator updateValidator, ILogger<RoleController> logger)
        {
            _roleService = roleService;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateRoleDTO dto)
        {
            var validResult = await _createValidator.ValidateAsync(dto);

            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors);
            }

            var response = await _roleService.CreateAsync(dto);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateRoleDTO dto)
        {
            var validResult = await _updateValidator.ValidateAsync(dto);

            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors);
            }

            var response = await _roleService.UpdateAsync(dto);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("id is required!");
            }

            var response = await _roleService.DeleteAsync(id);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("id is required!");
            }

            var response = await _roleService.GetByIdAsync(id);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _roleService.GetAllAsync();
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}
