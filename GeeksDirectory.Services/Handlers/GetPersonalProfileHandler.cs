#pragma warning disable CS1998

using AutoMapper;

using GeeksDirectory.Domain.Entities;
using GeeksDirectory.Domain.Interfaces;
using GeeksDirectory.Services.Mappings;
using GeeksDirectory.Services.Queries;
using GeeksDirectory.Domain.Classes;
using GeeksDirectory.Domain.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GeeksDirectory.Services.Handlers
{
    public class GetPersonalProfileHandler : IRequestHandler<GetPersonalProfileQuery, GeekProfileResponse>
    {
        private readonly HttpContext httpContext;
        private UserManager<ApplicationUser> userManager;
        private readonly IProfilesRepository repository;
        private readonly IMapper mapper;

        public GetPersonalProfileHandler(
            IHttpContextAccessor httpContextAccessor, 
            UserManager<ApplicationUser> userManager, 
            IProfilesRepository repository, 
            IMapperService mapperService)
        {
            this.httpContext = httpContextAccessor.HttpContext;
            this.userManager = userManager;
            this.repository = repository;
            this.mapper = mapperService.GetDataMapper();
        }

        public async Task<GeekProfileResponse> Handle(GetPersonalProfileQuery request, CancellationToken cancellationToken)
        {
            var userName = await this.userManager.GetUserAsync(httpContext.User);

            var profile = this.repository.GetProfileByUserName(userName.Email);
            return this.mapper.Map<GeekProfileResponse>(profile);
        }
    }
}
