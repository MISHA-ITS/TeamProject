namespace SPR311_DreamTeam_Rozetka.BLL.DTOs.Category
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
