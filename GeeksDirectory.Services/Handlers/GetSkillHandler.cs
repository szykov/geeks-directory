#pragma warning disable CS1998

using AutoMapper;

using GeeksDirectory.Data.Entities;
using GeeksDirectory.Data.Repositories.Interfaces;
using GeeksDirectory.Services.Mappings;
using GeeksDirectory.Services.Queries;
using GeeksDirectory.SharedTypes.Classes;
using GeeksDirectory.SharedTypes.Responses;

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GeeksDirectory.Services.Handlers
{
    public class GetSkillHandler : IRequestHandler<GetSkillQuery, SkillResponse>
    {
        private readonly ISkillsRepository repository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        public GetSkillHandler(
            UserManager<ApplicationUser> userManager,
            ISkillsRepository repository,
            IMapperService mapperService)
        {
            this.userManager = userManager;
            this.repository = repository;
            this.mapper = mapperService.GetDataMapper();
        }

        public async Task<SkillResponse> Handle(GetSkillQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var skill = this.repository.Get(request.ProfileId, request.SkillName);
                return this.mapper.Map<SkillResponse>(skill);
            }
            catch (Exception ex) when (ex is KeyNotFoundException || ex is ArgumentException)
            {
                throw new LogicException(ex.Message, ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
        }
    }
}
