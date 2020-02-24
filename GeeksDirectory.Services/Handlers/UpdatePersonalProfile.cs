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
    public class UpdatePersonalProfile : IRequestHandler<UpdatePersonalProfileCommand, Result<int>>
    {
        private readonly HttpContext httpContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProfilesRepository repository;
        private readonly IMapper mapper;

        public UpdatePersonalProfile(
            IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager,
            IProfilesRepository repository, IMapperService mapperService)
        {
            this.httpContext = httpContextAccessor.HttpContext;
            this.userManager = userManager;
            this.repository = repository;
            this.mapper = mapperService.GetDataMapper();
        }

        public async Task<Result<int>> Handle(UpdatePersonalProfileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await this.userManager.GetUserAsync(httpContext.User);

                var entity = this.repository.GetProfileByUserName(user.Email);
                this.mapper.Map(request.Profile, entity);

                this.repository.Update(entity);

                return Results.Ok(entity.ProfileId);
            }
            catch (Exception ex) when (ex is KeyNotFoundException || ex is ArgumentException || ex is ArgumentNullException)
            {
                throw new LogicException(ex.Message, ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
        }
    }
}
