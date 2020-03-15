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
    public class GetSkillEvaluationHanlder : IRequestHandler<GetSkillEvaluationQuery, AssessmentResponse?>
    {
        private readonly string connection;

        public GetSkillEvaluationHanlder(IConfiguration configuration)
        {
            this.connection = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<AssessmentResponse?> Handle(GetSkillEvaluationQuery request, CancellationToken cancellationToken)
        {
            using var db = new SqliteConnection(this.connection);
            var sql = @"SELECT A.[AssessmentId] as Id,
                               P.[Email],
                               A.[Score]
                        FROM   [Profiles] AS P 
                               LEFT JOIN [Skills] AS S 
                                      ON P.[ProfileId] = S.[ProfileId] 
                               LEFT JOIN [Assessments] AS A 
                                      ON S.[Skillid] = A.[skillid] 
                        WHERE  P.[Profileid] = @ProfileId 
                               AND S.[SkillId] = @SkillId 
                               AND A.[UserId] = @UserId";
            var assesment = await db.QuerySingleAsync<AssessmentResponse>(sql, new { request.ProfileId, request.SkillId, request.UserId });

            return assesment;
        }
    }
}
