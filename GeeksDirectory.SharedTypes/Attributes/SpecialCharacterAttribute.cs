#pragma warning disable 8600, 8602

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace GeeksDirectory.Data.Attributes
{
    public class SpecialCharacterAttribute : ValidationAttribute
    {
        private readonly bool condition;

        public SpecialCharacterAttribute(bool condition = true)
        {
            this.condition = condition;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string valueToCheck = value is null ? String.Empty : value.ToString();

            // If no value then we don't check
            if (String.IsNullOrEmpty(valueToCheck.ToString()))
                return GetErrorMessage(validationContext.DisplayName);

            var regexItem = new Regex(@"[!#$@%^&*()_+\-=\[\]{};':""\\|,.<>\/?]");
            var result = regexItem.IsMatch(valueToCheck);

            return result == this.condition ? ValidationResult.Success : GetErrorMessage(validationContext.DisplayName);
        }

        public ValidationResult GetErrorMessage(string fieldName)
        {
            var msg = this.condition ?
                $"The field {fieldName} should have special characters." :
                $"The field {fieldName} should not have special characters.";

            return new ValidationResult(msg);
        }
    }
}
