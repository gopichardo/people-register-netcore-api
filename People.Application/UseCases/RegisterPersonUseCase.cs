using FluentValidation;
using People.Domain.Entities;
using People.Domain.Interfaces;

namespace People.Application.UseCases
{
    public class RegisterPersonUseCase : IRegisterPersonUseCase
    {
        private readonly IPersonRepository _repository;
        private readonly IValidator<Person> _personValidator;

        public RegisterPersonUseCase(
            IPersonRepository repository,
            IValidator<Person> personValidator
        )
        {
            _repository = repository;
            _personValidator = personValidator;
        }

        public async Task ExecuteAsync(Person person)
        {
            var validationResult = await _personValidator.ValidateAsync(person);

            if (!validationResult.IsValid)
            {
                var errors =
                    validationResult.Errors.Select(e => e.ErrorMessage).ToList()
                    as IEnumerable<FluentValidation.Results.ValidationFailure>;

                throw new ValidationException("Invalid person data", errors);
            }

            await _repository.AddAsync(person);
        }
    }
}
