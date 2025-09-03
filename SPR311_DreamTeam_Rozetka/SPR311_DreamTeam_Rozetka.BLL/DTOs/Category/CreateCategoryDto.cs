using System.ComponentModel.DataAnnotations;

namespace SPR311_DreamTeam_Rozetka.BLL.DTOs.Category
{
    public class CreateCategoryDto
    {
        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
    }
}