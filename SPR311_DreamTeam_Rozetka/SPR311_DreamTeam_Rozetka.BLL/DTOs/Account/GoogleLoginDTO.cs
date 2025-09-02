using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPR311_DreamTeam_Rozetka.BLL.DTOs.Account
{
    public class GoogleLoginDTO
    {
        [Required]
        public string IdToken { get; set; } = string.Empty;

        [Required]
        public string GoogleId { get; set; } = string.Empty;

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Picture { get; set; }
    }
}
