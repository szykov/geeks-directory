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

        public Assessment? Get(int profileId, int skillId, string userId)
        {
            if (skillId == 0 || profileId == 0 || String.IsNullOrEmpty(userId))
                throw new ArgumentException(message: $"Arguments {nameof(skillId)}/{nameof(profileId)}/{nameof(userId)} are invalid.");

            var skill = this.GetSkill(profileId, skillId);

            return skill.Assessments.Where(s => s.User.Id == userId).SingleOrDefault();
        }

        public void Add(int profileId, int skillId, string userId, int score)
        {
            if (skillId == 0 || profileId == 0 || String.IsNullOrEmpty(userId))
                throw new ArgumentException(message: $"Arguments {nameof(skillId)}/{nameof(profileId)}/{nameof(userId)} are invalid.");

            var skill = this.GetSkill(profileId, skillId);
            var assessment = new Assessment() { SkillId = skill.SkillId, UserId = userId, Score = score };

            this.context.Assessments.Add(assessment);
            this.context.SaveChanges();
        }

        public void Update(int profileId, int skillId, string userId, int score)
        {
            if (skillId == 0 || profileId == 0 || String.IsNullOrEmpty(userId))
                throw new ArgumentException(message: $"Arguments {nameof(skillId)}/{nameof(profileId)}/{nameof(userId)} are invalid.");

            var skill = this.GetSkill(profileId, skillId);
            var assessment = skill.Assessments.Where(s => s.User.Id == userId).SingleOrDefault()
                ?? throw new KeyNotFoundException("Assessment has not been found.");

            assessment.Score = score;

            this.context.Assessments.Update(assessment);
            this.context.SaveChanges();
        }

        public bool Exists(int profileId, int skillId, string userId)
        {
            if (profileId == 0 || skillId == 0 || String.IsNullOrEmpty(userId))
                throw new ArgumentException(message: $"Arguments {nameof(skillId)}/{nameof(profileId)}/{nameof(userId)} are invalid.");

            Skill skill = this.GetSkill(profileId, skillId);

            return skill.Assessments.Where(a => a.User.Id == userId).Any();
        }

        private Skill GetSkill(int profileId, int skillId)
        {
            return this.context.Skills
                .Include(s => s.Assessments)
                .ThenInclude(s => s.User)
                .Where(s => s.ProfileId == profileId)
                .Where(s => s.SkillId == skillId).SingleOrDefault()
                ?? throw new KeyNotFoundException("Skill has not been found.");
        }
    }
}
