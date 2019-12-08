using GeeksDirectory.SharedTypes.Responses;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace GeeksDirectory.SharedTypes.Classes
{
    public class CustomErrorResponseProvider : IErrorResponseProvider
    {
        public IActionResult CreateResponse(ErrorResponseContext context)
        {
            var errorResponse = new ErrorResponse() { Code = context.ErrorCode, Message = context.Message };
            return new ObjectResult(errorResponse) { StatusCode = context.StatusCode };
        }
    }
}
