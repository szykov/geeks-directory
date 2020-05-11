#pragma warning disable CS1998

using Dapper;

using GeeksDirectory.Domain.Responses;
using GeeksDirectory.Services.Helpers;
using GeeksDirectory.Services.Queries;

using MediatR;

using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GeeksDirectory.Services.Handlers
{
    public class GetProfilesHandler : IRequestHandler<GetProfilesQuery, (IEnumerable<GeekProfileResponse> profiles, long total)>
    {
        private readonly string connection;

        public GetProfilesHandler(IConfiguration configuration)
        {
            this.connection = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<(IEnumerable<GeekProfileResponse> profiles, long total)> Handle(GetProfilesQuery request, CancellationToken cancellationToken)
        {
            using var db = new SqliteConnection(this.connection);

            var options = request.queryOptions;
            var sql = $@"SELECT   P.[Id],
                                  P.[Email],
                                  P.[Name],
                                  P.[Surname],
                                  P.[Middlename],
                                  P.[City],
                                  S.[Id],
                                  S.[Name],
                                  S.[Description],
                                  S.[AverageScore]
                        FROM      [Profiles] AS P
                        LEFT JOIN [Skills]   AS S
                        ON        S.[ProfileId] = P.[Id]
                        WHERE     P.[Id] IN (SELECT [Id] FROM [Profiles]
                                                    ORDER BY  {options.OrderBy} {options.OrderDirection}
                                                    LIMIT @Limit OFFSET @Offset)
                        ORDER BY  P.{options.OrderBy} {options.OrderDirection};";

            var profiles = new Dictionary<long, GeekProfileResponse>();
            await db.QueryAsync<GeekProfileResponse, SkillResponse, GeekProfileResponse>(sql,
                map: (profile, skill) =>
                {
                    if (profiles.TryGetValue(profile.Id, out var found))
                        found.Skills.AddIfNotEmpty(skill);
                    else
                    {
                        profile.Skills.AddIfNotEmpty(skill);
                        profiles.Add(profile.Id, profile);
                    }

                    return profile;
                },
                param: new
                {
                    options.Limit,
                    options.Offset
                },
                splitOn: "Id");


            var total = await db.QueryFirstAsync<long>("SELECT COUNT() FROM [Profiles];");
            return (profiles.Values.ToList(), total);
        }
    }
}
