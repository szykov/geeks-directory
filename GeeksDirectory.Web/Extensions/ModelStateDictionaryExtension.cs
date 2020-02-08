using GeeksDirectory.SharedTypes.Classes;
using GeeksDirectory.SharedTypes.Responses;

using Microsoft.AspNetCore.Mvc.ModelBinding;

using System;
using System.Collections.Generic;

namespace GeeksDirectory.Web.Extensions
{
    public static class ModelStateDictionaryExtension
    {
        public static ErrorResponse ToErrorResponse(this ModelStateDictionary modelState)
        {
            if (modelState is null)
                throw new ArgumentNullException(paramName: nameof(modelState));

            var modelValidationErrors = new List<ModelValidationError>();
            foreach (KeyValuePair<string, ModelStateEntry> modelEntry in modelState)
            {
                foreach (var modelError in modelEntry.Value.Errors)
                {
                    var error = new ModelValidationError(message: modelError.ErrorMessage, target: modelEntry.Key);
                    modelValidationErrors.Add(error);
                };
            }

            var errorResponse = new ErrorResponse("Model state is invalid", ExceptionCode.UnprocessableEntity.ToString());
            errorResponse.Details = modelValidationErrors;

            return errorResponse;
        }
    }
}
