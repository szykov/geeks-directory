#nullable disable

using GeeksDirectory.Domain.Entities;
using GeeksDirectory.Infrastructure.Seed;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeeksDirectory.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<GeekProfile> Profiles { get; set; }

        public virtual DbSet<Skill> Skills { get; set; }

        public virtual DbSet<Assessment> Assessments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<GeekProfile>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<GeekProfile>()
                .HasKey(p => p.ProfileId);

            builder.Entity<GeekProfile>()
                .Property(p => p.ProfileId)
                .ValueGeneratedOnAdd();

            builder.Entity<GeekProfile>()
                .HasMany(p => p.Skills)
                .WithOne(s => s.Profile)
                .HasForeignKey(s => s.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Skill>()
                .HasKey(s => s.SkillId);

            builder.Entity<Skill>()
                .Property(s => s.SkillId)
                .ValueGeneratedOnAdd();

            builder.Entity<Skill>()
                .HasMany(s => s.Assessments)
                .WithOne(a => a.Skill)
                .HasForeignKey(a => a.SkillId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Assessment>()
                .HasKey(a => a.AssessmentId);

            builder.Entity<Assessment>()
                .HasOne(a => a.User)
                .WithMany(u => u.Assessments)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Seed();
        }
    }
}
