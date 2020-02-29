using GeeksDirectory.Domain.Classes;
using GeeksDirectory.Domain.Interfaces;
using GeeksDirectory.Domain.SchemaFilters.Responses;

using Swashbuckle.AspNetCore.Annotations;

using System.Collections.Generic;

namespace GeeksDirectory.Domain.Responses
{
    [SwaggerSchemaFilter(typeof(ErrorResponseSchemaFilter))]
    public class ErrorResponse
    {
        public string? Code { get; set; }

        public string? Message { get; set; }

        public IEnumerable<IErrorDetail>? Details { get; set; }

        public ErrorResponse() { }

        public ErrorResponse(ExceptionCode code)
        {
            this.Code = code.ToString();

            switch (code)
            {
                case ExceptionCode.Unauthorized:
                    this.Message = "You're not authorized or your session has expired.";
                    break;

                case ExceptionCode.InternalServerError:
                    this.Message = "Oops! Something went wrong.";
                    break;

                case ExceptionCode.NotAcceptable:
                    this.Message = "The server does not have a current representation that would be acceptable.";
                    break;

                case ExceptionCode.MethodNotAllowed:
                    this.Message = "The method received in the request-line is not supported by the target resource.";
                    break;

                default:
                    this.Message = "We can't seem to find the answer you're looking for.";
                    break;
            }
        }

        public ErrorResponse(string code, string message) 
        {
            this.Code = code;
            this.Message = message;
        }
    }
}
