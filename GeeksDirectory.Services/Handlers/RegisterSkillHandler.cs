#pragma warning disable CS1998

using AutoMapper;

using FluentResults;

using GeeksDirectory.Domain.Entities;
using GeeksDirectory.Domain.Interfaces;
using GeeksDirectory.Services.Commands;
using GeeksDirectory.Services.Mappings;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace GeeksDirectory.Services.Handlers
{
    public class RegisterSkillHandler : IRequestHandler<RegisterSkillCommand, Result>
    {
        private readonly ISkillsRepository repository;
        private readonly IMapper mapper;

        public RegisterSkillHandler(ISkillsRepository repository, IMapperService mapperService)
        {
            this.repository = repository;
            this.mapper = mapperService.GetDataMapper();
        }

        public async Task<Result> Handle(RegisterSkillCommand request, CancellationToken cancellationToken)
        {
            if (this.repository.Exists(request.ProfileId, request.Skill.Name))
                return Results.Fail("Skill already exists.");

            var skill = this.mapper.Map<Skill>(request.Skill);
            this.repository.Add(request.ProfileId, skill);

            return Results.Ok();
        }
    }
}
