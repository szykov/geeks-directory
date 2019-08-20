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
            var errorExceptions = new List<ErrorException>();
            foreach (KeyValuePair<string, ModelStateEntry> modelEntry in modelState)
            {
                foreach (var modelError in modelEntry.Value.Errors)
                {
                    errorExceptions.Add(new ErrorException()
                    {
                        Message = modelError.ErrorMessage,
                        Target = modelEntry.Key
                    });
                }
            }

            var errorResponse = new ErrorResponse()
            {
                Message = "Model state is invalid",
                Code = ExceptionCode.UnprocessableEntity.ToString(),
                Details = errorExceptions
            };

            return errorResponse;
        }
    }
}
