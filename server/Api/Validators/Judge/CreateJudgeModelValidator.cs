using BLL.Models.Coach;
using BLL.Models.Judge;
using FluentValidation;
namespace Api.Validators.Judge
{
    public class CreateJudgeModelValidator: AbstractValidator<CreateJudgeModel>
    {
        public CreateJudgeModelValidator()
        {
            RuleFor(j => j.JudgeCategory)
                .NotEmpty().WithMessage("Judge Category must not be empty");
        }
    }
}
