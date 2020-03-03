#pragma warning disable CS1998

using AutoMapper;

using FluentResults;

using GeeksDirectory.Domain.Entities;
using GeeksDirectory.Domain.Interfaces;
using GeeksDirectory.Services.Mappings;
using GeeksDirectory.Services.Queries;
using GeeksDirectory.Domain.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using System.Threading;
using System.Threading.Tasks;

namespace GeeksDirectory.Services.Handlers
{
    public class GetMySkillEvaluationHanlder : IRequestHandler<GetMySkillEvaluationQuery, AssessmentResponse?>
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

        public async Task<AssessmentResponse?> Handle(GetMySkillEvaluationQuery request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(httpContext.User);

            var assesment = this.repository.Get(request.ProfileId, request.SkillName, user.Id);
            return this.mapper.Map<AssessmentResponse?>(assesment);
        }
    }
}
