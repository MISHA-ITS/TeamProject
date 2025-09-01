using FluentValidation;
using SPR311_DreamTeam_Rozetka.BLL.DTOs.Role;

namespace SPR311_DreamTeam_Rozetka.BLL.Validators.Role
{
    public class UpdateValidator : AbstractValidator<UpdateRoleDTO>
    {
        public UpdateValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id ролі обов'язковий для оновлення");

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Ідентифікатор ролі обов’язковий");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Назва ролі обов'язкова")
                .MinimumLength(4).WithMessage("Назва ролі повинна містити не менше 4 символів")
                .MaximumLength(50).WithMessage("Назва ролі не повинна перевищувати 50 символів");
        }
    }
}
