using FluentValidation;
using SPR311_DreamTeam_Rozetka.BLL.DTOs.Account;

namespace SPR311_DreamTeam_Rozetka.BLL.Validators.Account
{
    public class RegisterValdator : AbstractValidator<RegisterDTO>
    {
        public RegisterValdator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Вкажіть адресу електронної пошти")
                .EmailAddress().WithMessage("Невірний формат електронної пошти");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Вкажіть ім'я користувача")
                .MinimumLength(3).WithMessage("Ім'я повинно містити не менше трьох символів");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Пароль обов'язковий")
                .MinimumLength(6).WithMessage("Мінімальна довжина паролю 6 символів");
        }
    }
}
