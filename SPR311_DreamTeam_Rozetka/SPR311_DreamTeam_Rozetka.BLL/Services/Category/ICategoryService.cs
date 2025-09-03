using SPR311_DreamTeam_Rozetka.BLL.DTOs.Category;

namespace SPR311_DreamTeam_Rozetka.BLL.Services.Category
{
    public interface ICategoryService
    {
        Task<ServiceResponse> CreateAsync(CreateCategoryDto dto);
        Task<ServiceResponse> UpdateAsync(UpdateCategoryDto dto);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<ServiceResponse> GetByIdAsync(Guid id);
        Task<ServiceResponse> GetAllAsync();
    }
}
