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
using System.Threading;
using System.Threading.Tasks;

namespace GeeksDirectory.Services.Handlers
{
    public class RegisterProfileHandler : IRequestHandler<RegisterProfileCommand, Result<int>>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProfilesRepository repository;
        private readonly IMapper mapper;

        public RegisterProfileHandler(
            UserManager<ApplicationUser> userManager,
            IProfilesRepository repository,
            IMapperService mapperService)
        {
            this.userManager = userManager;
            this.repository = repository;
            this.mapper = mapperService.GetDataMapper();
        }

        public async Task<Result<int>> Handle(RegisterProfileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (this.repository.UserExists(request.Profile.Email))
                    return Results.Fail<int>("Profile already exists.");

                var applicationUser = await this.CreateUser(request.Profile.Email, request.Profile.Password);

                var profile = this.mapper.Map<GeekProfile>(request.Profile);
                profile.User = applicationUser;

                this.repository.Add(profile);

                return Results.Ok(profile.ProfileId);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is ArgumentNullException)
            {
                throw new LogicException(ex.Message, ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
        }


        private async Task<ApplicationUser> CreateUser(string email, string password)
        {
            var normalizedEmail = email.Normalize().ToUpperInvariant();
            var applicationUser = new ApplicationUser
            {
                UserName = email,
                Email = email,
                NormalizedEmail = normalizedEmail,
                NormalizedUserName = normalizedEmail,
                Id = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var passwordHash = this.userManager.PasswordHasher.HashPassword(applicationUser, password);
            applicationUser.PasswordHash = passwordHash;

            await this.userManager.CreateAsync(applicationUser, password);

            return applicationUser;
        }
    }
}
