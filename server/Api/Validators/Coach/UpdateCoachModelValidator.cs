using BLL.Models.Coach;
using FluentValidation;

namespace Api.Validators.Coach
{
    public class UpdateCoachModelValidator: AbstractValidator<UpdateCoachModel>
    {
        public UpdateCoachModelValidator()
        {
            RuleFor(c => c.Phone)
                .NotEmpty().WithMessage("Phone must not be empty");
        }
    }
}
