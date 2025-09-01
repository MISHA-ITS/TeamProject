﻿using Microsoft.AspNetCore.Http;

namespace SPR311_DreamTeam_Rozetka.BLL.DTOs.User
{
    public class UpdateUserDTO
    {
        public required string Id { get; set; }
        public required string Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public IFormFile? Image { get; set; }
    }
}
