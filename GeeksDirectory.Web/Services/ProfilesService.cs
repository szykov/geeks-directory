using AutoMapper;

using GeeksDirectory.Data.Entities;
using GeeksDirectory.Data.Repositories;
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
            this.mapper = mapperService.GetGeekProfileMapper();
            this.logger = logger;
        }

        public IEnumerable<GeekProfileResponse> Get(int take, int skip)
        {
            try
            {
                var profiles = this.repository.Get(take, skip);
                return this.mapper.Map<IEnumerable<GeekProfileResponse>>(profiles);
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

        public void Update(int profileId, GeekProfileModel profile)
        {
            try
            {
                var entity = this.repository.Get(profileId);
                this.mapper.Map(profile, entity);

                this.repository.Update(profileId, entity);

                this.logger.LogInformation("Updated profile {@entity} with {@profile}", entity, profile);
            }
            catch (Exception ex) when (ex is KeyNotFoundException || ex is ArgumentException || ex is ArgumentNullException)
            {
                throw new LogicException(ex.Message, ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
        }

        public async Task<GeekProfileResponse> AddAsync(GeekProfileModel model)
        {
            try
            {
                var exists = await this.userManager.FindByEmailAsync(model.Email);
                if (exists != null)
                {
                    throw new ArgumentException("Profile already exists.");
                }

                var applicationUser = new ApplicationUser { UserName = model.Email, Email = model.Email };
                await this.userManager.CreateAsync(applicationUser, model.Password);

                var profile = this.mapper.Map<GeekProfile>(model);
                profile.ApplicationUser = applicationUser;

                this.repository.Add(profile);

                this.logger.LogInformation("Added profile {@entity} with {@profile}", profile, model);

                return this.mapper.Map<GeekProfileResponse>(profile);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is ArgumentNullException)
            {
                throw new LogicException(ex.Message, ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
        }
    }
}
