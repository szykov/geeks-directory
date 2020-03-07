using GeeksDirectory.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace GeeksDirectory.Infrastructure.Seed
{
    internal static class ModelBuilderExtensions
    {
        internal static void Seed(this ModelBuilder modelBuilder)
        {
            var data = new SeedData();

            modelBuilder.Entity<ApplicationUser>().HasData(data.ApplicationUsers);
            modelBuilder.Entity<GeekProfile>().HasData(data.GeekProfiles);
            modelBuilder.Entity<Skill>().HasData(data.Skills);
            modelBuilder.Entity<Assessment>().HasData(data.Assessments);
        }
    }
}
