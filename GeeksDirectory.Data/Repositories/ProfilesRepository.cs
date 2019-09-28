using GeeksDirectory.Data.Entities;
using GeeksDirectory.Data.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;

namespace GeeksDirectory.Data.Repositories
{
    public class ProfilesRepository : IProfilesRepository
    {
        private readonly ApplicationDbContext context;

        public ProfilesRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<GeekProfile> Get(int take, int skip)
        {
            if (take <= 0 || skip < 0)
            {
                throw new ArgumentException(message: $"Arguments {nameof(take)}/{nameof(skip)} are invalid.");
            }

            return this.context.Profiles
                .Include(prf => prf.Skills)
                .Include(prf => prf.User)
                .Take(take).Skip(skip)
                .ToList();
        }

        public GeekProfile Get(int profileId)
        {
            if (profileId == 0)
            {
                throw new ArgumentException(message: $"Argument {nameof(profileId)} is invalid.");
            }

            var profile = this.context.Profiles
                .Include(prf => prf.Skills)
                .Include(prf => prf.User)
                .Where(prf => prf.ProfileId == profileId)
                .SingleOrDefault();

            if (profile == null)
            {
                throw new KeyNotFoundException("Profile has not been found.");
            }

            return profile;
        }

        public GeekProfile Get(string userName)
        {
            if (String.IsNullOrEmpty(userName))
            {
                throw new ArgumentException(message: $"Argument {nameof(userName)} is invalid.");
            }

            var profile = this.context.Profiles
                .Include(prf => prf.Skills)
                .Include(prf => prf.User)
                .Where(prf => prf.User.UserName == userName)
                .SingleOrDefault();

            if (profile == null)
            {
                throw new KeyNotFoundException("Profile has not been found.");
            }

            return profile;
        }

        public IEnumerable<GeekProfile> Search(string searchQuery)
        {
            if (String.IsNullOrEmpty(searchQuery))
            {
                throw new ArgumentNullException(paramName: nameof(searchQuery));
            }

            return this.context.Profiles.Where(prf => 
                EF.Functions.Like(prf.Name, searchQuery) ||
                EF.Functions.Like(prf.Surname, searchQuery) ||
                EF.Functions.Like(prf.MiddleName, searchQuery) ||
                EF.Functions.Like(prf.City, searchQuery) ||
                EF.Functions.Like(String.Join(" ", prf.Skills.Select(s => s.Description)), searchQuery) ||
                EF.Functions.Like(String.Join(" ", prf.Skills.Select(s => s.Name)), searchQuery));
        }

        public void Update(GeekProfile profile)
        {
            if (profile == null)
            {
                throw new ArgumentNullException(paramName: nameof(profile));
            }

            this.context.Profiles.Update(profile);
            context.SaveChanges();
        }

        public void Add(GeekProfile profile)
        {
            if (profile == null)
            {
                throw new ArgumentNullException(paramName: nameof(profile));
            }

            this.context.Profiles.Add(profile);
            context.SaveChanges();
        }
    }
}
