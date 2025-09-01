using SPR311_DreamTeam_Rozetka.DAL.Entities;

namespace SPR311_DreamTeam_Rozetka.DAL.Repositories.Product
{
    public interface IProductRepository
    {
        Task<bool> CreateAsync(ProductEntity entity);
        Task<bool> UpdateAsync(ProductEntity entity);
        Task<bool> DeleteAsync(ProductEntity entity);
        Task<ProductEntity> GetByIdAsync(int id);
        IQueryable<ProductEntity> GetAll();
        bool IsUniqueName(ProductEntity entity);
    }
}
