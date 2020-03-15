#nullable disable

using GeeksDirectory.Domain.Classes;
using GeeksDirectory.Domain.Entities;
using GeeksDirectory.Infrastructure.Seed;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Hosting;

using System;

namespace GeeksDirectory.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
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
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.HasOne(u => u.Profile)
                    .WithOne(p => p.User)
                    .HasForeignKey<GeekProfile>(p => p.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });


            builder.Entity<GeekProfile>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Id)
                    .ValueGeneratedOnAdd();

                entity.HasMany(p => p.Skills)
                    .WithOne(s => s.Profile)
                    .HasForeignKey(s => s.ProfileId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Skill>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.Property(s => s.Id)
                    .ValueGeneratedOnAdd();

                entity.HasMany(s => s.Assessments)
                    .WithOne(a => a.Skill)
                    .HasForeignKey(a => a.SkillId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Assessment>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.HasOne(a => a.User)
                    .WithMany(u => u.Assessments)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            var env = this.GetService<IWebHostEnvironment>();
            if (env.IsDevelopment())
            {
                builder.Seed();
            }
        }
    }
}
