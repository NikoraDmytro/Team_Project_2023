using BLL.Models.Club;
using FluentValidation;

namespace Api.Validators.Club
{
    public class CreateClubModelValidator: AbstractValidator<CreateClubModel>
    {
        public CreateClubModelValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name must not be empty");

            RuleFor(c => c.City)
                .NotEmpty().WithMessage("City must not be empty");

            RuleFor(c => c.Address)
                .NotEmpty().WithMessage("Address must not be empty");
        }
    }
}
