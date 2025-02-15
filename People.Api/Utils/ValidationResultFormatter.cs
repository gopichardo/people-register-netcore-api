using FluentValidation.Results;

namespace People.Api.Utils
{
    public class ValidationResultFormatter : IValidationResultFormatter
    {
        public List<ValidationResponse> Format(ValidationResult validationResult)
        {
            return validationResult
                .Errors.Select(x => new ValidationResponse
                {
                    PropertyName = x.PropertyName,
                    ErrorMessage = x.ErrorMessage
                })
                .ToList();
        }
    }
}
