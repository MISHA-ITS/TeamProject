using SPR311_DreamTeam_Rozetka.BLL.DTOs.Role;

namespace SPR311_DreamTeam_Rozetka.BLL.Services.Role
{
    public interface IRoleService
    {
        Task<ServiceResponse> CreateAsync(CreateRoleDTO dto);
        Task<ServiceResponse> UpdateAsync(UpdateRoleDTO dto);
        Task<ServiceResponse> DeleteAsync(string id);
        Task<ServiceResponse> GetByIdAsync(string id);
        Task<ServiceResponse> GetAllAsync();
    }
}
