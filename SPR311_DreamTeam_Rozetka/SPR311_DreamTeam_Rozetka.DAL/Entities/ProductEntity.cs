using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPR311_DreamTeam_Rozetka.DAL.Entities
{
    public class ProductEntity
    {
        [Key]
        public Guid id {  get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        public virtual CategoryEntity? Category { get; set; }
    }
}
