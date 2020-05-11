#pragma warning disable CS1998

using Dapper;

using GeeksDirectory.Domain.Responses;
using GeeksDirectory.Services.Queries;

using MediatR;

using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

using System.Threading;
using System.Threading.Tasks;

namespace GeeksDirectory.Services.Handlers
{
    public class GetSkillHandler : IRequestHandler<GetSkillQuery, SkillResponse?>
    {
        private readonly string connection;

        public GetSkillHandler(IConfiguration configuration)
        {
            this.connection = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<SkillResponse?> Handle(GetSkillQuery request, CancellationToken cancellationToken)
        {
            using var db = new SqliteConnection(this.connection);

            var sql = @"SELECT [Id],
                               [Name],
                               [Description],
                               [AverageScore],
                               [Profileid]
                        FROM   [Skills] AS S
                        WHERE  S.[ProfileId] = @ProfileId
                               AND S.[Id] = @SkillId;";

            var skills = await db.QuerySingleOrDefaultAsync<SkillResponse>(sql, new { request.ProfileId, request.SkillId });

            return skills;
        }
    }
}
