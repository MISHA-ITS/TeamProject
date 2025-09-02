using SPR311_DreamTeam_Rozetka.BLL.DTOs.Account;

namespace SPR311_DreamTeam_Rozetka.BLL.Services.Account
{
    public interface IAccountService
    {
        Task<ServiceResponse> LoginAsync(LoginDTO dto);
        Task<ServiceResponse?> RegisterAsync(RegisterDTO dto);
        Task<ServiceResponse> GoogleLoginAsync(GoogleLoginDTO dto);
    }
}
