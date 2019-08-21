using GeeksDirectory.Data.Entities;

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

        public Skill Get(int profileId, string skillTitle)
        {
            if (profileId == 0 || String.IsNullOrEmpty(skillTitle))
            {
                throw new ArgumentException(message: $"{nameof(profileId)} or {nameof(skillTitle)} are invalid.");
            }

            var profile = this.context.Profiles.Where(prf => prf.ProfileId == profileId).SingleOrDefault();

            if (profile == null)
            {
                throw new KeyNotFoundException("Profile has not been found.");
            }

            var skill = profile.Skills.Where(s => s.Title == skillTitle).Single();

            if (skill == null)
            {
                throw new KeyNotFoundException("Skill has not been found.");
            }

            return skill;
        }

        public void Add(int profileId, Skill skill)
        {
            if (profileId == 0 || skill == null)
            {
                throw new ArgumentException(message: $"{nameof(profileId)} or {nameof(skill)} are invalid.");
            }

            var profile = this.context.Profiles.Where(prf => prf.ProfileId == profileId).SingleOrDefault()
                ?? throw new KeyNotFoundException("Profile has not been found.");

            skill.Profile = profile;

            this.context.Skills.Add(skill);
            this.context.SaveChanges();
        }

        public void SetScore(Skill skill, int score)
        {
            skill.Score = score;
            this.context.SaveChanges();
        }
    }
}
