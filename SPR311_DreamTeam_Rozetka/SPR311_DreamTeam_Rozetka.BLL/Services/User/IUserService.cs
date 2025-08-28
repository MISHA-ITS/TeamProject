using SPR311_DreamTeam_Rozetka.BLL.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPR311_DreamTeam_Rozetka.BLL.Services.User
{
    public interface IUserService
    {
        Task<ServiceResponse> CreateAsync(CreateUserDTO dto);
        Task<ServiceResponse> UpdateAsync(UpdateUserDTO dto);
        Task<ServiceResponse> DeleteAsync(string id);
        Task<ServiceResponse?> GetByIdAsync(string id);
        Task<ServiceResponse> GetAllAsync();
    }
}
