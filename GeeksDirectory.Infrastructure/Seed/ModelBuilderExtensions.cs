using GeeksDirectory.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace GeeksDirectory.Infrastructure.Seed
{
    internal static class ModelBuilderExtensions
    {
        internal static void Seed(this ModelBuilder modelBuilder)
        {
            var data = new SeedData();

            modelBuilder.Entity<ApplicationUser>().HasData(data.GetApplicationUsers());
            modelBuilder.Entity<GeekProfile>().HasData(data.GetGeekProfiles());
            modelBuilder.Entity<Skill>().HasData(data.GetSkills());
        }
    }
}
