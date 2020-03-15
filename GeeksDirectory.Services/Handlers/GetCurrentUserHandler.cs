#pragma warning disable CS1998

using Dapper;

using GeeksDirectory.Domain.Entities;
using GeeksDirectory.Services.Queries;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

using System.Threading;
using System.Threading.Tasks;

namespace GeeksDirectory.Services.Handlers
{
    public class GetCurrentUserHandler : IRequestHandler<GetCurrentUserQuery, ApplicationUser>
    {
        private readonly HttpContext httpContext;
        private readonly string connection;

        public GetCurrentUserHandler(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            this.httpContext = httpContextAccessor.HttpContext;
            this.connection = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<ApplicationUser> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            using var db = new SqliteConnection(this.connection);

            var sql = @"SELECT * FROM [AspNetUsers] WHERE [UserName] = @Email";
            var user = await db.QuerySingleOrDefaultAsync<ApplicationUser>(sql, new { Email = httpContext.User.Identity.Name });

            return user;
        }

    }
}
