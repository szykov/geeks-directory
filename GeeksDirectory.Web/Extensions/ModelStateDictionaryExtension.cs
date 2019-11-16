using GeeksDirectory.SharedTypes.Classes;
using GeeksDirectory.SharedTypes.Responses;

using Microsoft.AspNetCore.Mvc.ModelBinding;

using System.Collections.Generic;

namespace GeeksDirectory.SharedTypes.Extensions
{
    public static class ModelStateDictionaryExtension
    {
        public static ErrorResponse ToErrorResponse(this ModelStateDictionary modelState)
        {
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
