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
                        FROM   [profiles] AS P 
                               LEFT JOIN [skills] AS S 
                                      ON P.[profileid] = S.[profileid] 
                               LEFT JOIN [assessments] AS A 
                                      ON S.[skillid] = A.[skillid] 
                        WHERE  P.[profileid] = @ProfileId 
                               AND S.[skillId] = @SkillId 
                               AND A.[userid] = @UserId";
            var assesment = db.QuerySingleOrDefault<AssessmentResponse>(sql, new { request.ProfileId, request.SkillId, request.UserId });

            return assesment;
        }
    }
}
