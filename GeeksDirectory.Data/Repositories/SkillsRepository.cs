using GeeksDirectory.Data.Entities;
using GeeksDirectory.Data.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;

namespace GeeksDirectory.Data.Repositories
{
    public class SkillsRepository : ISkillsRepository
    {
        private readonly ApplicationDbContext context;

        public SkillsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Skill Get(int profileId, string skillName)
        {
            if (profileId == 0 || String.IsNullOrEmpty(skillName))
                throw new ArgumentException(message: $"Arguments {nameof(profileId)}/{nameof(skillName)} are invalid.");

            var skill = this.context.Skills
                .Include(s => s.Assessments)
                .ThenInclude(s => s.User)
                .Where(s => s.Profile.ProfileId == profileId)
                .Where(s => s.Name == skillName)
                .SingleOrDefault();

            if (skill is null)
                throw new KeyNotFoundException("Skill has not been found.");

            return skill;
        }

        public bool Exists(int profileId, string skillName)
        {
            if (profileId == 0 || String.IsNullOrEmpty(skillName))
                throw new ArgumentException(message: $" Arguments {nameof(profileId)} or {nameof(skillName)} are invalid.");

            return this.context.Skills.Where(s => s.Profile.ProfileId == profileId)
                .Where(s => s.Name == skillName).Any();
        }

        public void Add(int profileId, Skill skill)
        {
            if (profileId == 0 || skill == null)
                throw new ArgumentException(message: $" Arguments {nameof(profileId)} or {nameof(skill)} are invalid.");

            var profile = this.context.Profiles.Where(prf => prf.ProfileId == profileId).SingleOrDefault()
                ?? throw new KeyNotFoundException("Profile has not been found.");

            skill.Profile = profile;

            this.context.Skills.Add(skill);
            this.context.SaveChanges();
        }

        public Skill RefreshAverageScore(int profileId, string skillName)
        {
            if (profileId == 0 || String.IsNullOrEmpty(skillName))
                throw new ArgumentException(message: $"Arguments {nameof(profileId)}/{nameof(skillName)} are invalid.");

            var skill = this.Get(profileId, skillName);
            var averageScore = Convert.ToInt32(skill.Assessments.Average(a => a.Score));

            skill.AverageScore = averageScore;

            this.context.Skills.Update(skill);
            this.context.SaveChanges();

            return skill;
        }
    }
}
