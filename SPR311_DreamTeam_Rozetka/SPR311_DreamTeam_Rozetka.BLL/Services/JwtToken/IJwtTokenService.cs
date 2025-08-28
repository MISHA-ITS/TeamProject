using SPR311_DreamTeam_Rozetka.DAL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPR311_DreamTeam_Rozetka.BLL.Services.JwtToken
{
    public interface IJwtTokenService
    {
        string GenerateToken(AppUser user);
    }
}
