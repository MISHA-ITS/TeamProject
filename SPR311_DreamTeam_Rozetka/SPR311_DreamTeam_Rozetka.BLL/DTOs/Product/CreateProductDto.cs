using System.ComponentModel.DataAnnotations;


namespace SPR311_DreamTeam_Rozetka.BLL.DTOs.Product
{
    public class CreateProductDto
    {
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
    }
}
