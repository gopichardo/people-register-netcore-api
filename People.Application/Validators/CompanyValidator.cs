using FluentValidation;
using People.Domain.Entities;

namespace People.Application.Validators
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Company Name is required.");
        }
    }
}
