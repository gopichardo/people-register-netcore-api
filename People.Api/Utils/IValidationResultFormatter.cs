using FluentValidation.Results;

namespace People.Api.Utils
{
    public class ValidationResponse
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }

    public interface IValidationResultFormatter
    {
        public List<ValidationResponse> Format(ValidationResult validationResult);
    }
}
