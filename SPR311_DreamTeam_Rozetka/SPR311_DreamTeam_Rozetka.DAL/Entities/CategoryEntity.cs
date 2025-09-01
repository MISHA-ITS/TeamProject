using System.ComponentModel.DataAnnotations;


namespace SPR311_DreamTeam_Rozetka.DAL.Entities
{
    public class CategoryEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public virtual ICollection<ProductEntity> Products { get; set; } = [];
    }
}
