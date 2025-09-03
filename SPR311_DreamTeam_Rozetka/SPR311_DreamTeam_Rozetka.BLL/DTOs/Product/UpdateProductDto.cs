using System.ComponentModel.DataAnnotations;

namespace SPR311_DreamTeam_Rozetka.BLL.DTOs.Product
{
    public class UpdateProductDto
    {
        [Required]
        public Guid Id { get; set; }

        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal? Price { get; set; }

        public Guid? CategoryId { get; set; }
    }
}
