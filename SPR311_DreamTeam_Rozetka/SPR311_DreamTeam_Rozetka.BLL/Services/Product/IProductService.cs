using SPR311_DreamTeam_Rozetka.BLL.DTOs.Product;

namespace SPR311_DreamTeam_Rozetka.BLL.Services.Product
{
    public interface IProductService
    {
        Task<ServiceResponse> CreateAsync(CreateProductDto dto);
        Task<ServiceResponse> UpdateAsync(UpdateProductDto dto);
        Task<ServiceResponse> DeleteAsync(int id);
        Task<ServiceResponse> GetByIdAsync(int id);
        Task<ServiceResponse> GetAllAsync();
    }
}
