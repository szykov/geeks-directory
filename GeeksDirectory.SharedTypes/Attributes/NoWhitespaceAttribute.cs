using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GeeksDirectory.Data.Attributes
{
    public class NoWhitespaceAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string valueToCheck = value is null ? String.Empty : value.ToString();

            // If no value then we don't check
            if (String.IsNullOrEmpty(valueToCheck.ToString()))
                return GetErrorMessage(validationContext.DisplayName);

            var result = !valueToCheck.ToString().Any(char.IsWhiteSpace);

            return result ? ValidationResult.Success : GetErrorMessage(validationContext.DisplayName);
        }

        public ValidationResult GetErrorMessage(string fieldName)
        {
            return new ValidationResult($"The field {fieldName} shouldn't have white spaces.");
        }
    }
}
