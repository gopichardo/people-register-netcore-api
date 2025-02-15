using System.Text.RegularExpressions;
using FluentValidation;
using People.Domain.Entities;

namespace People.Application.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nombre del Contacto es requerido.");
            RuleFor(x => x.Company.Name).NotEmpty().WithMessage("Nombre de la compañìa es requerido.");
            RuleFor(x => x.Phone)
                .NotEmpty()
                .Must(BeValidMexicanPhoneNumber)
                .WithMessage("Un teléfono válido es requerido.");
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Un correo válido es requerido.");
        }

        private bool BeValidMexicanPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return false;

            string cleanedNumber = Regex.Replace(phoneNumber, @"[^0-9]", ""); // Cleaning

            if (
                cleanedNumber.Length != 8
                && cleanedNumber.Length != 10
                && cleanedNumber.Length != 12
            )
                return false; // Length check

            if (cleanedNumber.Length == 12)
            { // Mobile prefixes check
                string prefix = cleanedNumber.Substring(0, 3);
                if (prefix != "044" && prefix != "045" && prefix != "041")
                    return false;
                cleanedNumber = cleanedNumber.Substring(3); // Remove prefix
            }

            string[] validAreaCodes =
            {
                "55",
                "81",
                "33", /* ... all other codes */
            };
            string areaCode = cleanedNumber.Substring(
                0,
                cleanedNumber.Length == 8
                    ? 2
                    : cleanedNumber.Length == 10
                        ? 2
                        : 3
            ); // Adjust for 8 or 10 digits
            if (!validAreaCodes.Contains(areaCode))
                return false; // Area code check

            // Optional: Simple regex format check (after cleaning and other checks)
            if (!Regex.IsMatch(cleanedNumber, "^[0-9]+$"))
                return false;

            return true;
        }
    }
}
