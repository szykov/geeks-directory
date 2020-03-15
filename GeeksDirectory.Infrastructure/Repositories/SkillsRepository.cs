using GeeksDirectory.Domain.Entities;
using GeeksDirectory.Domain.Interfaces;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;

namespace GeeksDirectory.Infrastructure.Repositories
{
    public class SkillsRepository : ISkillsRepository
    {
        private readonly ApplicationDbContext context;

        public SkillsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Skill? Get(long profileId, long skillId)
        {
            if (profileId == 0 || skillId == 0)
                throw new ArgumentException(message: $"Arguments {nameof(profileId)}/{nameof(skillId)} are invalid.");

            return this.context.Skills
                .Include(s => s.Assessments)
                .ThenInclude(s => s.User)
                .Where(s => s.Profile.Id == profileId)
                .Where(s => s.Id == skillId)
                .SingleOrDefault();
        }

        public bool Exists(long profileId, long skillId)
        {
            if (profileId == 0 || skillId == 0)
                throw new ArgumentException(message: $" Arguments {nameof(profileId)} or {nameof(skillId)} are invalid.");

            return this.context.Skills.Where(s => s.Profile.Id == profileId)
                .Where(s => s.Id == skillId).Any();
        }

        public void Add(long profileId, Skill skill)
        {
            if (profileId == 0 || skill == null)
                throw new ArgumentException(message: $" Arguments {nameof(profileId)} or {nameof(skill)} are invalid.");

            var profile = this.context.Profiles.Where(prf => prf.Id == profileId).SingleOrDefault()
                ?? throw new KeyNotFoundException("Profile has not been found.");

            skill.Profile = profile;

            this.context.Skills.Add(skill);
            this.context.SaveChanges();
        }

        public Skill RefreshAverageScore(long profileId, long skillId)
        {
            if (profileId == 0 || skillId == 0)
                throw new ArgumentException(message: $"Arguments {nameof(profileId)}/{nameof(skillId)} are invalid.");

            var skill = this.Get(profileId, skillId) ?? throw new KeyNotFoundException("Skill has not been found."); ;

            var averageScore = Convert.ToInt32(skill.Assessments.Average(a => a.Score));

            skill.AverageScore = averageScore;

            this.context.Skills.Update(skill);
            this.context.SaveChanges();

            return skill;
        }
    }
}
