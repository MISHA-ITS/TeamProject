using FluentValidation;
using SPR311_DreamTeam_Rozetka.BLL.DTOs.Category;

namespace SPR311_DreamTeam_Rozetka.BLL.Validators.Category
{
    public class UpdateValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Назва категорії є обов'язковою")
                .Length(2, 100).WithMessage("Назва повинна містити від 2 до 100 символів")
                .Matches(@"^[a-zA-Zа-яА-ЯїЇіІєЄґҐ0-9\s\-\'""()&.,!?]+$")
                .WithMessage("Назва містить недопустимі символи");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Опис не може перевищувати 500 символів")
                .When(x => !string.IsNullOrEmpty(x.Description));
        }
    }
}