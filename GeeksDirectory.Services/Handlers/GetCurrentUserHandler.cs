#pragma warning disable CS1998

using GeeksDirectory.Domain.Entities;
using GeeksDirectory.Services.Queries;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GeeksDirectory.Services.Handlers
{
    public class GetCurrentUserHandler : IRequestHandler<GetCurrentUserQuery, ApplicationUser>
    {
        private readonly HttpContext httpContext;
        private readonly UserManager<ApplicationUser> userManager;

        public GetCurrentUserHandler(
            IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager)
        {
            this.httpContext = httpContextAccessor.HttpContext;
            this.userManager = userManager;
        }

        public async Task<ApplicationUser> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            return await this.userManager.Users
                .Include(u => u.Profile)
                .SingleAsync(u => u.UserName == httpContext.User.Identity.Name);
        }

    }
}
