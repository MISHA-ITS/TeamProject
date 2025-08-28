using Microsoft.AspNetCore.Identity;
using SPR311_DreamTeam_Rozetka.BLL.DTOs.Account;
using SPR311_DreamTeam_Rozetka.BLL.Services.JwtToken;
using SPR311_DreamTeam_Rozetka.DAL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPR311_DreamTeam_Rozetka.BLL.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtTokenService _jwtTokenService;


        public AccountService(UserManager<AppUser> userManager, IJwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<ServiceResponse?> RegisterAsync(RegisterDTO dto)
        {
            if (!await IsUniqueEmailAsync(dto.Email))
            {
                return ServiceResponse.Error($"Адреса електронної пошти {dto.Email} вже існує");
            }

            if (!await IsUniqueNameAsync(dto.Name))
            {
                return ServiceResponse.Error($"Ім'я {dto.Name} вже існує");
            }

            var user = new AppUser
            {
                UserName = dto.Name,
                Email = dto.Email
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
            {
                string jwtToken = _jwtTokenService.GenerateToken(user);

                return ServiceResponse.Success("Реєтрація успішна", jwtToken);
            }

            return ServiceResponse.Error(result.Errors.First().Description);
        }

        public async Task<ServiceResponse> LoginAsync(LoginDTO dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                return ServiceResponse.Error($"Користувача {dto.Email} не знайдено!");
            }

            var result = await _userManager.CheckPasswordAsync(user, dto.Password);

            if (!result)
            {
                return ServiceResponse.Error($"Неправильний пароль!");
            }

            string jwtToken = _jwtTokenService.GenerateToken(user);

            return ServiceResponse.Success("Успішний вхід", jwtToken);
        }

        private async Task<bool> IsUniqueEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user == null;
        }

        private async Task<bool> IsUniqueNameAsync(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            return user == null;
        }

        public async Task<ServiceResponse> ConfirmEmailAsync(string userId, string token)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token))
            {
                return ServiceResponse.Error("Невірний запит на підтвердження.");
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return ServiceResponse.Error("Користувача не знайдено.");
            }

            try
            {
                byte[] bytes = Convert.FromBase64String(token);
                token = Encoding.UTF8.GetString(bytes);
            }
            catch
            {
                return ServiceResponse.Error("Некоректний токен.");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (!result.Succeeded)
            {
                return ServiceResponse.Error("Не вдалося підтвердити електронну пошту.");
            }

            return ServiceResponse.Success("Електронна пошта успішно підтверджена.");
        }
    }
}
