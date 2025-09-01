﻿using FluentValidation;
using SPR311_DreamTeam_Rozetka.BLL.DTOs.User;

namespace SPR311_DreamTeam_Rozetka.BLL.Validators.User
{
    public class UpdateValidator : AbstractValidator<UpdateUserDTO>
    {
        public UpdateValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id обов'язковий для оновлення");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Вкажіть адресу електронної пошти")
                .EmailAddress().WithMessage("Невірний формат електронної пошти");

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Вкажіть ім'я користувача")
                .MinimumLength(3).WithMessage("Ім'я повинно містити не менше трьох символів")
                .MaximumLength(50).WithMessage("Ім'я не повинно перевищувати 50 символів")
                .When(x => !string.IsNullOrWhiteSpace(x.FirstName));

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Вкажіть прізвище користувача")
                .MinimumLength(3).WithMessage("Прізвище повинно містити не менше трьох символів")
                .MaximumLength(50).WithMessage("Прізвище не повинно перевищувати 50 символів")
                .When(x => !string.IsNullOrWhiteSpace(x.LastName));
        }
    }
}
