using FluentResults;

using GeeksDirectory.Domain.Responses;

using Microsoft.AspNetCore.Mvc;

using System.Linq;

namespace GeeksDirectory.Web.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected UnprocessableEntityObjectResult UnprocessableEntity(Result result)
        {
            return base.UnprocessableEntity(new ErrorResponse() { Message = result.Reasons.First().Message });
        }
    }
}
