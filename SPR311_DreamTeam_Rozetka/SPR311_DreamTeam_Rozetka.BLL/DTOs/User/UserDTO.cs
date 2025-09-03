namespace SPR311_DreamTeam_Rozetka.BLL.DTOs.User
{
    public class UserDTO
    {
        public required string Id { get; set; }
        public required string Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Image { get; set; }
        public string[] Roles { get; set; } = [];
    }
}
