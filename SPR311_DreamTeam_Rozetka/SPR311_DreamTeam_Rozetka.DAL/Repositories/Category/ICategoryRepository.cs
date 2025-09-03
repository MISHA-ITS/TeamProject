using SPR311_DreamTeam_Rozetka.DAL.Entities;

namespace SPR311_DreamTeam_Rozetka.DAL.Repositories.Category
{
    public interface ICategoryRepository
    {
        Task<bool> CreateAsync(CategoryEntity entity);
        Task<bool> UpdateAsync(CategoryEntity entity);
        Task<bool> DeleteAsync(CategoryEntity entity);
        Task<CategoryEntity> GetByIdAsync(Guid id);
        IQueryable<CategoryEntity> GetAll();
        bool IsUniqueName(CategoryEntity entity);
    }
}
