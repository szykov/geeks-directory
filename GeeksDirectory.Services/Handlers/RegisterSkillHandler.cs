#pragma warning disable CS1998

using AutoMapper;

using FluentResults;

using GeeksDirectory.Data.Entities;
using GeeksDirectory.Data.Repositories.Interfaces;
using GeeksDirectory.Services.Commands;
using GeeksDirectory.Services.Mappings;
using GeeksDirectory.SharedTypes.Classes;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GeeksDirectory.Services.Handlers
{
    public class RegisterSkillHandler : IRequestHandler<RegisterSkillCommand, Result>
    {
        private readonly HttpContext httpContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ISkillsRepository repository;
        private readonly IMapper mapper;

        public RegisterSkillHandler(
            IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager,
            ISkillsRepository repository,
            IMapperService mapperService)
        {
            this.httpContext = httpContextAccessor.HttpContext;
            this.userManager = userManager;
            this.repository = repository;
            this.mapper = mapperService.GetDataMapper();
        }

        public async Task<Result> Handle(RegisterSkillCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (this.repository.Exists(request.ProfileId, request.Skill.Name))
                    throw new ArgumentException("Skill already exists.");

                var skill = this.mapper.Map<Skill>(request.Skill);
                this.repository.Add(request.ProfileId, skill);

                var user = await this.userManager.GetUserAsync(httpContext.User);

                return Results.Ok();

                /*var skillEvaluation = new SkillEvaluationModel() { Score = request.Skill.Score };
                var updatedSkill = await this.EvaluateSkillAsync(request.ProfileId, request.Skill.Name, user.Email, skillEvaluation);

                return this.mapper.Map<SkillResponse>(updatedSkill);*/
            }
            catch (Exception ex) when (ex is KeyNotFoundException || ex is ArgumentException)
            {
                throw new LogicException(ex.Message, ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
        }
    }
}
