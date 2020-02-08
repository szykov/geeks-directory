using GeeksDirectory.Data.Entities;
using GeeksDirectory.Data.Repositories.Interfaces;
using GeeksDirectory.SharedTypes.Classes;

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

        public IEnumerable<GeekProfile> GetProfiles(QueryOptions queryOptions)
        {
            if (queryOptions is null)
                throw new ArgumentNullException(paramName: nameof(queryOptions));

            var result = this.context.Profiles
                .Include(prf => prf.Skills)
                .Include(prf => prf.User)
                .AsQueryable();

            if (queryOptions.IsSortable())
                result = this.Sort(result, queryOptions.OrderDirection, queryOptions.OrderBy!);

            return result.Skip(queryOptions.Offset).Take(queryOptions.Limit);
        }

        public GeekProfile GetProfileById(int profileId)
        {
            if (profileId == 0)
                throw new ArgumentException(message: $"Argument {nameof(profileId)} is invalid.");

            var profile = this.context.Profiles
                .Include(prf => prf.Skills)
                .Include(prf => prf.User)
                .Where(prf => prf.ProfileId == profileId)
                .SingleOrDefault();

            if (profile is null)
                throw new KeyNotFoundException("Profile has not been found.");

            return profile;
        }

        public GeekProfile GetProfileByUserName(string userName)
        {
            if (String.IsNullOrEmpty(userName))
                throw new ArgumentException(message: $"Argument {nameof(userName)} is invalid.");

            var profile = this.context.Profiles
                .Include(prf => prf.Skills)
                .Include(prf => prf.User)
                .Where(prf => prf.User.UserName == userName)
                .SingleOrDefault();

            if (profile is null)
                throw new KeyNotFoundException("Profile has not been found.");

            return profile;
        }

        public IEnumerable<GeekProfile> Search(QueryOptions queryOptions, out int total)
        {
            if (queryOptions is null)
                throw new ArgumentNullException(paramName: nameof(queryOptions));

            if (String.IsNullOrEmpty(queryOptions.Query))
                throw new ArgumentNullException(paramName: nameof(queryOptions.Query));


            var result = this.context.Profiles
                .Include(prf => prf.Skills)
                .Include(prf => prf.User)
                .Where(prf => EF.Functions.Like(prf.Name, queryOptions.Query) ||
                    EF.Functions.Like(prf.Surname, queryOptions.Query) ||
                    EF.Functions.Like(prf.MiddleName, queryOptions.Query) ||
                    EF.Functions.Like(prf.City, queryOptions.Query) ||
                    prf.Skills.Any(skl => EF.Functions.Like(skl.Name, queryOptions.Query)));

            total = result.Count();

            if (queryOptions.IsSortable())
                result = this.Sort(result, queryOptions.OrderDirection, queryOptions.OrderBy!);

            return result.Skip(queryOptions.Offset).Take(queryOptions.Limit);
        }

        public void Update(GeekProfile profile)
        {
            if (profile is null)
                throw new ArgumentNullException(paramName: nameof(profile));

            this.context.Profiles.Update(profile);
            context.SaveChanges();
        }

        public void Add(GeekProfile profile)
        {
            if (profile is null)
                throw new ArgumentNullException(paramName: nameof(profile));

            this.context.Profiles.Add(profile);
            context.SaveChanges();
        }

        public int Total()
        {
            return this.context.Profiles.Count();
        }

        private IQueryable<GeekProfile> Sort(IQueryable<GeekProfile> profiles, OrderDirection orderDirection, string OrderBy)
        {
            return orderDirection == OrderDirection.Ascending ? 
                profiles.OrderBy(p => EF.Property<object>(p, OrderBy)) : 
                profiles.OrderByDescending(p => EF.Property<object>(p, OrderBy));
        }
    }
}
