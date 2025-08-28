using SPR311_DreamTeam_Rozetka.BLL.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPR311_DreamTeam_Rozetka.BLL.Services.Account
{
    public interface IAccountService
    {
        Task<ServiceResponse> LoginAsync(LoginDTO dto);
        Task<ServiceResponse?> RegisterAsync(RegisterDTO dto);
    }
}
