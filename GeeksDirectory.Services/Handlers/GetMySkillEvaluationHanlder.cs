#pragma warning disable CS1998

using AutoMapper;

using FluentResults;

using GeeksDirectory.Data.Entities;
using GeeksDirectory.Data.Repositories.Interfaces;
using GeeksDirectory.Services.Mappings;
using GeeksDirectory.Services.Queries;
using GeeksDirectory.SharedTypes.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using System.Threading;
using System.Threading.Tasks;

namespace GeeksDirectory.Services.Handlers
{
    public class GetMySkillEvaluationHanlder : IRequestHandler<GetMySkillEvaluationQuery, Result<AssessmentResponse>>
    {
        private readonly HttpContext httpContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;
        private readonly IAssessmentsRepository repository;

        public GetMySkillEvaluationHanlder(
            IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager,
            IMapperService mapperService,
            IAssessmentsRepository repository)
        {
            this.httpContext = httpContextAccessor.HttpContext;
            this.userManager = userManager;
            this.mapper = mapperService.GetDataMapper();
            this.repository = repository;
        }

        public async Task<Result<AssessmentResponse>> Handle(GetMySkillEvaluationQuery request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(httpContext.User);

            if (!this.repository.Exists(request.ProfileId, request.SkillName, user.Id))
            {
                return Results.Fail("Assesment doesn't exist.");
            }

            var assesment = this.mapper.Map<AssessmentResponse>(this.repository.Get(request.ProfileId, request.SkillName, user.Id));
            return Results.Ok(assesment);
        }
    }
}
