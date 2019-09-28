using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GeeksDirectory.Data.Attributes
{
    public class NoWhitespaceValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string valueToCheck = value is null ? String.Empty : value.ToString();

            // If no value then we don't check
            if (String.IsNullOrEmpty(valueToCheck.ToString()))
                return true;

            var validationFlag = !valueToCheck.ToString().Any(char.IsWhiteSpace);

            return validationFlag;
        }
    }
}
