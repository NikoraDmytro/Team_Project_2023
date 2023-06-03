using BLL.Models.Judge;
using FluentValidation;
namespace Api.Validators.Judge
{
    public class UpdateJudgeModelValidator: AbstractValidator<CreateJudgeModel>
    {
        public UpdateJudgeModelValidator()
        {
            RuleFor(j => j.JudgeCategory)
               .NotEmpty().WithMessage("Judge Category must not be empty");
        }
    }
}
