using AutoMapper;

using GeeksDirectory.Data.Entities;
using GeeksDirectory.Data.Repositories.Interfaces;
using GeeksDirectory.SharedTypes.Classes;
using GeeksDirectory.SharedTypes.Models;
using GeeksDirectory.SharedTypes.Responses;
using GeeksDirectory.Web.Services.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeeksDirectory.Web.Services
{
    public class ProfilesService : IProfilesService
    {
        private readonly IProfilesRepository repository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public ProfilesService(IProfilesRepository repository, UserManager<ApplicationUser> userManager, IMapperService mapperService, ILogger<ProfilesService> logger)
        {
            this.repository = repository;
            this.userManager = userManager;
            this.mapper = mapperService.GetDataMapper();
            this.logger = logger;
        }

        public GeekProfileResponses Get(int limit, int offset)
        {
            try
            {
                var profiles = this.repository.Get(limit, offset);
                var total = this.repository.Total();

                var profileResponses = this.mapper.Map<IEnumerable<GeekProfileResponse>>(profiles);
                return new GeekProfileResponses()
                {
                    Pagination = new PaginationResponse() { Limit = limit, Offset = offset, Total = total },
                    Data = profileResponses
                };
            }
            catch (ArgumentException ex)
            {
                throw new LogicException(ex.Message, ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
        }

        public GeekProfileResponse Get(int profileId)
        {
            try
            {
                var profile = this.repository.Get(profileId);
                return this.mapper.Map<GeekProfileResponse>(profile);
            }
            catch (Exception ex) when (ex is KeyNotFoundException || ex is ArgumentException)
            {
                throw new LogicException(ex.Message, ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
        }

        public GeekProfileResponse Get(string userName)
        {
            try
            {
                var profile = this.repository.Get(userName);
                return this.mapper.Map<GeekProfileResponse>(profile);
            }
            catch (Exception ex) when (ex is KeyNotFoundException || ex is ArgumentException)
            {
                throw new LogicException(ex.Message, ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
        }

        public IEnumerable<GeekProfileResponse> Search(string searchQuery)
        {
            try
            {
                var profiles = this.repository.Search(searchQuery);
                return this.mapper.Map<IEnumerable<GeekProfileResponse>>(profiles);
            }
            catch (ArgumentNullException ex)
            {
                throw new LogicException(ex.Message, ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
        }

        public GeekProfileResponse Update(string userName, GeekProfileModel profile)
        {
            try
            {
                var entity = this.repository.Get(userName);
                this.mapper.Map(profile, entity);

                this.repository.Update(entity);

                this.logger.LogInformation("Updated profile {@entity} with {@profile}", entity, profile);

                return this.mapper.Map<GeekProfileResponse>(entity);
            }
            catch (Exception ex) when (ex is KeyNotFoundException || ex is ArgumentException || ex is ArgumentNullException)
            {
                throw new LogicException(ex.Message, ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
        }

        public async Task<GeekProfileResponse> AddAsync(CreateGeekProfileModel model)
        {
            try
            {
                var applicationUser = await CreateUser(model.Email, model.Password);

                var profile = this.mapper.Map<GeekProfile>(model);
                profile.User = applicationUser;

                this.repository.Add(profile);

                this.logger.LogInformation("Added profile {@entity}", profile);

                return this.mapper.Map<GeekProfileResponse>(profile);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is ArgumentNullException)
            {
                throw new LogicException(ex.Message, ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
        }

        private async Task<ApplicationUser> CreateUser(string email, string password)
        {
            var normalizedEmail = email.Normalize().ToUpperInvariant();

            var exists = await this.userManager.FindByEmailAsync(email);
            if (exists != null)
            {
                throw new ArgumentException("Profile already exists.");
            }

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

            this.logger.LogInformation("Created user {0}", email);

            return applicationUser;
        }
    }
}
