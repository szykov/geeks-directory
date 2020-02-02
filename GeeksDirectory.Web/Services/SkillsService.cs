﻿using AutoMapper;

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

        public async Task<SkillResponse> AddAsync(int profileId, SkillModel model, string userEmail)
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

                var user = await this.userManager.FindByEmailAsync(userEmail);

                var skillEvaluation = new SkillEvaluationModel() { Score = model.Score };
                var updatedSkill = await this.EvaluateSkillAsync(profileId, model.Name, userEmail, skillEvaluation);

                return this.mapper.Map<SkillResponse>(updatedSkill);
            }
            catch (Exception ex) when (ex is KeyNotFoundException || ex is ArgumentException)
            {
                throw new LogicException(ex.Message, ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
        }

        public async Task<SkillResponse> EvaluateSkillAsync(int profileId, string skillName, string userEmail, SkillEvaluationModel model)
        {
            try
            {
                var user = await this.userManager.FindByEmailAsync(userEmail);

                if (this.assessmentsRepository.Exists(profileId, skillName, user.Id))
                    this.assessmentsRepository.Update(profileId, skillName, user.Id, model.Score);
                else
                    this.assessmentsRepository.Add(profileId, skillName, user.Id, model.Score);

                this.logger.LogInformation("Set skill score for {0} of profile {1} by {2} to {3}", skillName, profileId, userEmail, model);

                var skill = this.skillsRepository.RefreshAverageScore(profileId, skillName);
                return this.mapper.Map<SkillResponse>(skill);
            }
            catch (Exception ex) when (ex is KeyNotFoundException || ex is ArgumentException)
            {
                throw new LogicException(ex.Message, ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
        }

        public async Task<AssessmentResponse?> TryGetMySkillEvaluationAsync(int profileId, string skillName, string userEmail)
        {
            var user = await this.userManager.FindByEmailAsync(userEmail);

            if (this.assessmentsRepository.Exists(profileId, skillName, user.Id))
                return this.mapper.Map<AssessmentResponse>(this.assessmentsRepository.Get(profileId, skillName, user.Id));

            return null;
        }
    }
}
