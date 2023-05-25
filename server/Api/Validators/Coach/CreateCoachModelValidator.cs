using BLL.Models.Coach;
using FluentValidation;

namespace Api.Validators.Coach
{
    public class CreateCoachModelValidator: AbstractValidator<CreateCoachModel>
    {
        public CreateCoachModelValidator()
        {
            RuleFor(c => c.Phone)
                .NotEmpty().WithMessage("Phone must not be empty");
        }
    }
}
