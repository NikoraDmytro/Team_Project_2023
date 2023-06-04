using BLL.Models.Coach;
using FluentValidation;

namespace Api.Validators.Coach
{
    public class CreateCoachModelValidator: AbstractValidator<CreateCoachModel>
    {
        public CreateCoachModelValidator()
        {
            
        }
    }
}
