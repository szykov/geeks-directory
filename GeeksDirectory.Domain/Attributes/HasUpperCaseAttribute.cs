#pragma warning disable 8600, 8602

using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GeeksDirectory.Domain.Attributes
{
    public class UpperCaseAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string valueToCheck = value is null ? String.Empty : value.ToString();

            // If no value then we don't check
            if (String.IsNullOrEmpty(valueToCheck.ToString()))
                return GetErrorMessage(validationContext.DisplayName);

            var result = valueToCheck.ToString().Any(char.IsUpper);

            return result ? ValidationResult.Success : GetErrorMessage(validationContext.DisplayName);
        }

        public ValidationResult GetErrorMessage(string fieldName)
        {
            return new ValidationResult($"The field {fieldName} should have uppercase letters.");
        }
    }
}
