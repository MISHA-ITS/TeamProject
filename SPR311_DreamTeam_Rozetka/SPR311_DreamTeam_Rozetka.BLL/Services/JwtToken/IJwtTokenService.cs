using SPR311_DreamTeam_Rozetka.DAL.Entities.Identity;

namespace SPR311_DreamTeam_Rozetka.BLL.Services.JwtToken
{
    public interface IJwtTokenService
    {
        string GenerateToken(AppUser user);
    }
}
