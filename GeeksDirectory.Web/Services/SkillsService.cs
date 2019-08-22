using AutoMapper;

using GeeksDirectory.Data.Entities;
using GeeksDirectory.Data.Repositories;
using GeeksDirectory.SharedTypes.Classes;
using GeeksDirectory.SharedTypes.Models;
using GeeksDirectory.SharedTypes.Responses;
using GeeksDirectory.Web.Services.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;

namespace GeeksDirectory.Web.Services
{
    public class SkillsService : ISkillsService
    {
        private readonly ISkillsRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public SkillsService(ISkillsRepository repository, IMapperService mapperService, ILogger<SkillsService> logger)
        {
            this.repository = repository;
            this.mapper = mapperService.GetSkillMapper();
            this.logger = logger;
        }

        public SkillResponse Get(int profileId, string skillName)
        {
            try
            {
                var skill = this.repository.Get(profileId, skillName);
                return this.mapper.Map<SkillResponse>(skill);
            }
            catch (Exception ex) when (ex is KeyNotFoundException || ex is ArgumentException)
            {
                throw new LogicException(ex.Message, ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
        }

        public SkillResponse Add(int profileId, SkillModel model)
        {
            try
            {
                if(this.repository.Exists(profileId, model.Name))
                {
                    throw new ArgumentException("Skill already exists.");
                }

                var skill = this.mapper.Map<Skill>(model);
                this.repository.Add(profileId, skill);

                return this.mapper.Map<SkillResponse>(skill);
            }
            catch (Exception ex) when (ex is KeyNotFoundException || ex is ArgumentException)
            {
                throw new LogicException(ex.Message, ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
        }

        public void SetScore(int profileId, string skillName, int score)
        {
            try
            {
                var skill = this.repository.Get(profileId, skillName);
                this.repository.SetScore(skill, score);
            }
            catch (Exception ex) when (ex is KeyNotFoundException || ex is ArgumentException)
            {
                throw new LogicException(ex.Message, ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
        }
    }
}
