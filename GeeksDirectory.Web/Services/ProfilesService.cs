using AutoMapper;

using GeeksDirectory.Data.Entities;
using GeeksDirectory.Data.Repositories;
using GeeksDirectory.SharedTypes.Classes;
using GeeksDirectory.SharedTypes.Models;
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

        public IEnumerable<GeekProfile> Get(int take, int skip)
        {
            try
            {
                return this.repository.Get(take, skip);
            }
            catch (Exception ex)
            {
                throw new LogicException(ex.Message, ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
        }

        public GeekProfile Get(int id)
        {
            try
            {
                return this.repository.Get(id);
            }
            catch (Exception ex)
            {
                throw new LogicException(ex.Message, ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
        }

        public IEnumerable<GeekProfile> Search(string searchQuery)
        {
            try
            {
                return this.repository.Search(searchQuery);
            }
            catch (Exception ex)
            {
                throw new LogicException(ex.Message, ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
        }

        public void Update(int id, GeekProfileModel profile)
        {
            try
            {
                var entity = this.repository.Get(id);
                this.mapper.Map(profile, entity);

                this.repository.Update(entity);

                this.logger.LogInformation("Updated profile {@entity} with {@profile}", entity, profile);
            }
            catch (Exception ex)
            {
                throw new LogicException(ex.Message, ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
        }

        public async Task<GeekProfile> AddAsync(GeekProfileModel profile)
        {
            var applicationUser = new ApplicationUser { UserName = profile.Email, Email = profile.Email };
            await this.userManager.CreateAsync(applicationUser, profile.Password);

            var entity = this.mapper.Map<GeekProfile>(profile);
            entity.ApplicationUser = applicationUser;

            this.repository.Add(entity);

            this.logger.LogInformation("Added profile {@entity} with {@profile}", entity, profile);

            return entity;
        }
    }
}
