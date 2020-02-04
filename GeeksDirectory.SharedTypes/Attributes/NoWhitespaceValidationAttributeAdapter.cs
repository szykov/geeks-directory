using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;

using System;

namespace GeeksDirectory.Data.Attributes
{
    public class NoWhitespaceValidationAttributeAdapter : AttributeAdapterBase<NoWhitespaceValidationAttribute>
    {
        public NoWhitespaceValidationAttributeAdapter(
            NoWhitespaceValidationAttribute attribute,
            IStringLocalizer stringLocalizer)
            : base(attribute, stringLocalizer) { }

        public override void AddValidation(ClientModelValidationContext context)
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-nowhitespace", this.GetErrorMessage(context));
        }

        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            return this.GetErrorMessage(validationContext.ModelMetadata,
                validationContext.ModelMetadata.GetDisplayName());
        }
    }
}
