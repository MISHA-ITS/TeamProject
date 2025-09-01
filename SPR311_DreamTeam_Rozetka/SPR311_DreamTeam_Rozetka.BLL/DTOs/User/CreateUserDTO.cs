using Microsoft.AspNetCore.Http;

namespace SPR311_DreamTeam_Rozetka.BLL.DTOs.User
{
    public class CreateUserDTO
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public IFormFile? Image { get; set; }
    }
}
