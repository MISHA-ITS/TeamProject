using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SPR311_DreamTeam_Rozetka.BLL.Configuration;
using SPR311_DreamTeam_Rozetka.DAL.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SPR311_DreamTeam_Rozetka.BLL.Services.JwtToken
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UserManager<AppUser> _userManager;
        public JwtTokenService(IOptions<JwtSettings> jwtOptions, UserManager<AppUser> userManager)
        {
            _jwtSettings = jwtOptions.Value;
            _userManager = userManager;
        }

        public string GenerateToken(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim("userId", user.Id),
                new Claim("email", user.Email ?? ""),
                //new Claim("name", user.UserName ?? ""),
                new Claim("firstname", user.FirstName ?? ""),
                new Claim("lastname" , user.LastName ?? ""),
                new Claim("image", user.Image != null? user.Image : "")
            };

            var roles = _userManager.GetRolesAsync(user).Result;

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var bytes = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);
            var securityKey = new SymmetricSecurityKey(bytes);

            var securityToken = new JwtSecurityToken(
                audience: _jwtSettings.Audience,
                issuer: _jwtSettings.Issuer,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpMinutes),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                );

            string jwtToken = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return jwtToken;
        }
    }
}
