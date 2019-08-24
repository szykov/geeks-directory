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
    public class SkillsService : ISkillsService
    {
        private readonly ISkillsRepository skillsRepository;
        private readonly IAssessmentsRepository assessmentsRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public SkillsService(ISkillsRepository skillsRepository, 
                             IAssessmentsRepository assessmentsRepository, 
                             UserManager<ApplicationUser> userManager, 
                             IMapperService mapperService, 
                             ILogger<SkillsService> logger)
        {
            this.skillsRepository = skillsRepository;
            this.assessmentsRepository = assessmentsRepository;
            this.userManager = userManager;
            this.mapper = mapperService.GetDataMapper();
            this.logger = logger;
        }

        public SkillResponse Get(int profileId, string skillName)
        {
            try
            {
                var skill = this.skillsRepository.Get(profileId, skillName);
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
                if (this.skillsRepository.Exists(profileId, model.Name))
                {
                    throw new ArgumentException("Skill already exists.");
                }

                var skill = this.mapper.Map<Skill>(model);
                this.skillsRepository.Add(profileId, skill);

                this.logger.LogInformation("Added skill {@skill} to {@profileId}", skill, profileId);

                return this.mapper.Map<SkillResponse>(skill);
            }
            catch (Exception ex) when (ex is KeyNotFoundException || ex is ArgumentException)
            {
                throw new LogicException(ex.Message, ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
        }

        public async Task EvaluateSkillAsync(int profileId, string skillName, string userEmail, int score)
        {
            try
            {
                var user = await this.userManager.FindByEmailAsync(userEmail);

                if (this.assessmentsRepository.Exists(profileId, skillName, user.Id))
                    this.assessmentsRepository.Update(profileId, skillName, user.Id, score);
                else
                    this.assessmentsRepository.Add(profileId, skillName, user.Id, score);

                this.skillsRepository.RefreshAverageScore(profileId, skillName);

                this.logger.LogInformation("Set skill score for {0} of profile {1} by {2} to {3}", skillName, profileId, userEmail, score);
            }
            catch (Exception ex) when (ex is KeyNotFoundException || ex is ArgumentException)
            {
                throw new LogicException(ex.Message, ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
        }
    }
}
