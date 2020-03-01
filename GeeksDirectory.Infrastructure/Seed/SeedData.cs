using GeeksDirectory.Domain.Entities;

using Microsoft.AspNetCore.Identity;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace GeeksDirectory.Infrastructure.Seed
{
    internal sealed class SeedData
    {
        private readonly string source = "../GeeksDirectory.Infrastructure/Seed/Mock";
        private readonly string password = "Pa$$w0rd";
        private readonly PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

        public IEnumerable<ApplicationUser> ApplicationUsers { get; private set; }
        public IEnumerable<GeekProfile> GeekProfiles { get; private set; }
        public IEnumerable<Skill> Skills { get; private set; }
        public IEnumerable<Assessment> Assessments { get; private set; }

        public SeedData()
        {
            using (StreamReader streamReader = new StreamReader(Path.Combine(this.source, "Users.json")))
            {
                string json = streamReader.ReadToEnd();
                this.ApplicationUsers = JsonSerializer.Deserialize<IEnumerable<ApplicationUser>>(json);

                foreach (var user in this.ApplicationUsers)
                {
                    user.NormalizedUserName = user.UserName.ToUpperInvariant().Normalize();
                    user.NormalizedEmail = user.Email.ToUpperInvariant().Normalize();
                    user.PasswordHash = this.hasher.HashPassword(default!, this.password);
                }
            }

            using (StreamReader streamReader = new StreamReader(Path.Combine(this.source, "Profiles.json")))
            {
                string json = streamReader.ReadToEnd();
                this.GeekProfiles = JsonSerializer.Deserialize<IEnumerable<GeekProfile>>(json);
            }

            using (StreamReader streamReader = new StreamReader(Path.Combine(this.source, "Skills.json")))
            {
                string json = streamReader.ReadToEnd();
                var skills =  JsonSerializer.Deserialize<IEnumerable<Skill>>(json);
                this.Skills = skills.Select(s => new Skill()
                {
                    SkillId = s.SkillId,
                    ProfileId = s.ProfileId,
                    Name = s.Name,
                    Description = s.Description,
                    AverageScore = s.Assessments.Sum(a => a.Score) / s.Assessments.Count()
                });

                this.Assessments = skills.SelectMany(s => s.Assessments)
                    .Select((a, index) => new Assessment()
                    {
                        AssessmentId = index + 1,
                        SkillId = a.SkillId,
                        UserId = a.UserId,
                        Score = a.Score
                    });
            }
        }
    }
}