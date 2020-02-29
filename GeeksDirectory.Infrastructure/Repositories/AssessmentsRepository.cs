using GeeksDirectory.Domain.Entities;
using GeeksDirectory.Domain.Interfaces;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;

namespace GeeksDirectory.Infrastructure.Repositories
{
    public class AssessmentsRepository : IAssessmentsRepository
    {
        private readonly ApplicationDbContext context;

        public AssessmentsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Assessment? Get(int profileId, string skillName, string userName)
        {
            if (String.IsNullOrEmpty(skillName) || profileId == 0 || String.IsNullOrEmpty(userName))
                throw new ArgumentException(message: $"Arguments {nameof(skillName)}/{nameof(profileId)}/{nameof(userName)} are invalid.");

            var skill = this.GetSkill(profileId, skillName);

            return skill.Assessments.Where(s => s.UserName == userName).SingleOrDefault();
        }

        public void Add(int profileId, string skillName, string userName, int score)
        {
            if (String.IsNullOrEmpty(skillName) || profileId == 0 || String.IsNullOrEmpty(userName))
                throw new ArgumentException(message: $"Arguments {nameof(skillName)}/{nameof(profileId)}/{nameof(userName)} are invalid.");

            var skill = this.GetSkill(profileId, skillName);
            var assessment = new Assessment() { SkillId = skill.SkillId, UserName = userName, Score = score };

            this.context.Assessments.Add(assessment);
            this.context.SaveChanges();
        }

        public void Update(int profileId, string skillName, string userName, int score)
        {
            if (String.IsNullOrEmpty(skillName) || profileId == 0 || String.IsNullOrEmpty(userName))
                throw new ArgumentException(message: $"Arguments {nameof(skillName)}/{nameof(profileId)}/{nameof(userName)} are invalid.");

            var skill = this.GetSkill(profileId, skillName);
            var assessment = skill.Assessments.Where(s => s.UserName == userName).SingleOrDefault()
                ?? throw new KeyNotFoundException("Assessment has not been found.");

            assessment.Score = score;

            this.context.Assessments.Update(assessment);
            this.context.SaveChanges();
        }

        public bool Exists(int profileId, string skillName, string userName)
        {
            if (profileId == 0 || String.IsNullOrEmpty(skillName) || String.IsNullOrEmpty(userName))
                throw new ArgumentException(message: $"Arguments {nameof(skillName)}/{nameof(profileId)}/{nameof(userName)} are invalid.");

            Skill skill = this.GetSkill(profileId, skillName);

            return skill.Assessments.Where(a => a.UserName == userName).Any();
        }

        private Skill GetSkill(int profileId, string skillName)
        {
            return this.context.Skills
                .Include(s => s.Assessments)
                .Where(s => s.ProfileId == profileId)
                .Where(s => s.Name == skillName).SingleOrDefault()
                ?? throw new KeyNotFoundException("Skill has not been found.");
        }
    }
}
