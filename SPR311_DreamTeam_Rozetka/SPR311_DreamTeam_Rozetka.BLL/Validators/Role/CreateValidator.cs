using FluentValidation;
using SPR311_DreamTeam_Rozetka.BLL.DTOs.Role;

namespace SPR311_DreamTeam_Rozetka.BLL.Validators.Role
{
    public class CreateValidator : AbstractValidator<CreateRoleDTO>
    {
        public CreateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Назва ролі обов'язкова")
                .MinimumLength(4).WithMessage("Назва ролі повинна містити не менше 4 символів")
                .MaximumLength(50).WithMessage("Назва ролі не повинна перевищувати 50 символів");
        }
    }
}
