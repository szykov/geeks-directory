using GeeksDirectory.Data.Entities;

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
                throw new ArgumentException(message: $"{nameof(take)} and/or {nameof(skip)} are invalid");
            }

            return this.context.Profiles.Take(take).Skip(skip).ToList();
        }

        public GeekProfile Get(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException(message: $"{nameof(id)} is invalid");
            }

            return this.context.Profiles.Where(prf => prf.ProfileId == id).Single();
        }

        public IEnumerable<GeekProfile> Search(string searchQuery)
        {
            if (String.IsNullOrEmpty(searchQuery))
            {
                throw new ArgumentNullException(paramName: nameof(searchQuery));
            }

            return this.context.Profiles.Where(prf => EF.Functions.FreeText(prf.Name, searchQuery))
                .Where(prf => EF.Functions.FreeText(prf.Surname, searchQuery))
                .Where(prf => EF.Functions.FreeText(prf.MiddleName, searchQuery))
                .Where(prf => EF.Functions.FreeText(prf.City, searchQuery))
                .Where(prf => EF.Functions.FreeText(String.Join(String.Empty, prf.Skills.Select(s => s.Description)), searchQuery))
                .Where(prf => EF.Functions.FreeText(String.Join(String.Empty, prf.Skills.Select(s => s.Title)), searchQuery));
        }

        public void Update(GeekProfile entity)
        {
            this.context.Profiles.Update(entity);
            context.SaveChanges();
        }

        public void Add(GeekProfile entity)
        {
            this.context.Profiles.Add(entity);
            context.SaveChanges();
        }
    }
}
