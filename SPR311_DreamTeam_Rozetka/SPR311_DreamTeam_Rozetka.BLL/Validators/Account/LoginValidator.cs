using FluentValidation;
using SPR311_DreamTeam_Rozetka.BLL.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPR311_DreamTeam_Rozetka.BLL.Validators.Account
{
    public class LoginValidator : AbstractValidator<LoginDTO>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Вкажіть адресу електронної пошти")
                .EmailAddress().WithMessage("Невірний формат електронної пошти");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Пароль обов'язковий")
                .MinimumLength(6).WithMessage("Мінімальна довжина паролю 6 символів");
        }
    }
}
