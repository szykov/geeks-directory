using GeeksDirectory.Data.Entities;
using GeeksDirectory.Data.Seed.Models;

using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;

namespace GeeksDirectory.Data.Seed
{
    internal class SeedData
    {
        private readonly PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

        private IEnumerable<ProfilesSeedModel> GetProfilesData()
        {
            yield return new ProfilesSeedModel()
            {
                Id = Guid.Parse("b8eb90fa-e25a-43e1-a5b6-dadfc2bcf2a1"),
                Name = "Sergey",
                Surname = "Zykov",
                City = "Moscow"
            };

            yield return new ProfilesSeedModel()
            {
                Id = Guid.Parse("0a50dbc4-23b5-4e0d-b588-0a7a72df0ed1"),
                Name = "John",
                Surname = "Smith",
                City = "Ekaterinburg"
            };

            yield return new ProfilesSeedModel()
            {
                Id = Guid.Parse("3fa5371e-5d44-42c6-b71f-daf3d38b2c5b"),
                Name = "Ivan",
                Surname = "Ivanov",
                City = "St. Petersburg"
            };

            yield return new ProfilesSeedModel()
            {
                Id = Guid.Parse("8636b3d5-af78-4a6f-a773-c96404516ba5"),
                Name = "Dasha",
                Surname = "Egorova",
                City = "Deport"
            };

            yield return new ProfilesSeedModel()
            {
                Id = Guid.Parse("4f99f9b1-b054-455e-9daa-8f0592823568"),
                Name = "Andrey",
                Surname = "Vladimirov",
                City = "Landmark"
            };

            yield return new ProfilesSeedModel()
            {
                Id = Guid.Parse("b270427f-fc46-4fdc-b3d9-3bdc64364d0e"),
                Name = "Violeta",
                Surname = "Kanygina",
                City = "New Preston"
            };

            yield return new ProfilesSeedModel()
            {
                Id = Guid.Parse("dc440a63-da95-43b0-98aa-3f4c4ff2a053"),
                Name = "Arsenia",
                Surname = "Panova",
                City = "Dupree"
            };

            yield return new ProfilesSeedModel()
            {
                Id = Guid.Parse("964fb987-c3d0-4a17-a417-fb7edce1e3aa"),
                Name = "Radislav",
                Surname = "Barsov",
                City = "Kenton Vale"
            };

            yield return new ProfilesSeedModel()
            {
                Id = Guid.Parse("46b27f3b-dca0-4b4a-8b2a-ab2b263c1171"),
                Name = "Vasya",
                Surname = "Alekseev",
                City = "Walnut Park"
            };

            yield return new ProfilesSeedModel()
            {
                Id = Guid.Parse("1a206a7d-646f-4c48-8578-1d2e6a76df05"),
                Name = "Zlata",
                Surname = "Tretyakova",
                City = "Karaichev"
            };

            yield return new ProfilesSeedModel()
            {
                Id = Guid.Parse("64642283-ef5f-4d48-9ef6-9a4e30b8332e"),
                Name = "Albert",
                Surname = "Archipov",
                City = "Golitsyno"
            };

            yield return new ProfilesSeedModel()
            {
                Id = Guid.Parse("bb88c60a-257e-4b84-9a07-45206ccb3aad"),
                Name = "Zarina",
                Surname = "Uvarova",
                City = "Trostyanka"
            };

            yield return new ProfilesSeedModel()
            {
                Id = Guid.Parse("ab9f49d7-f20a-4951-88db-f75fcded0fe9"),
                Name = "Nadezda",
                Surname = "Kolesnikova",
                City = "Stawropol"
            };

            yield return new ProfilesSeedModel()
            {
                Id = Guid.Parse("8bd9b467-e47b-4720-ad89-6eda8d254f86"),
                Name = "Alina",
                Surname = "Lazareva",
                City = "Lykoshina"
            };

            yield return new ProfilesSeedModel()
            {
                Id = Guid.Parse("a020921d-a94e-4606-b090-dc96d12ffd95"),
                Name = "Galena",
                Surname = "Volkova",
                City = "Agutino"
            };

            yield return new ProfilesSeedModel()
            {
                Id = Guid.Parse("83d419be-12fb-4c32-9079-44a6bf1f0086"),
                Name = "Vsevolod",
                Surname = "Lenin",
                City = "Ungavitsa"
            };

            yield return new ProfilesSeedModel()
            {
                Id = Guid.Parse("dabe2f8b-5545-4572-8468-5febf3a15a09"),
                Name = "Oskar",
                Surname = "Kapustin",
                City = "Shvedovo"
            };

            yield return new ProfilesSeedModel()
            {
                Id = Guid.Parse("4da310b4-87bb-4690-90c8-bf437114ae8e"),
                Name = "Vladimir",
                Surname = "Udin",
                City = "Skolkovo"
            };

            yield return new ProfilesSeedModel()
            {
                Id = Guid.Parse("73ad683c-7127-4b43-bc6c-c9e2a086d4c1"),
                Name = "Lubov",
                Surname = "Orehova",
                City = "Ragozina"
            };

            yield return new ProfilesSeedModel()
            {
                Id = Guid.Parse("ae8f195d-426c-45b3-8f56-17ef57fd3148"),
                Name = "Vlada",
                Surname = "Lipnitskaya",
                City = "Nikitino"
            };

            yield return new ProfilesSeedModel()
            {
                Id = Guid.Parse("f61dd9a6-49ee-4c40-ae5a-9b6b9122a38e"),
                Name = "Polina",
                Surname = "Davydova",
                City = "Aryntsas"
            };

            yield return new ProfilesSeedModel()
            {
                Id = Guid.Parse("d5a53242-1c53-42dd-8833-a5072b367d80"),
                Name = "Vanera",
                Surname = "Ryabova",
                City = "Krutilovka"
            };

            yield return new ProfilesSeedModel()
            {
                Id = Guid.Parse("98d7661f-19ac-4909-bf20-e700dd07c19a"),
                Name = "Anjela",
                Surname = "Trofimova",
                City = "Khvatkovo"
            };

            yield return new ProfilesSeedModel()
            {
                Id = Guid.Parse("511a47e8-9c86-4ce7-996f-9e1a72b53e69"),
                Name = "Oskar",
                Surname = "Davtyan",
                City = "Latoshinka"
            };

            yield return new ProfilesSeedModel()
            {
                Id = Guid.Parse("e30e2446-ad11-46d6-bc13-68097fae0440"),
                Name = "Nikolay",
                Surname = "Borisov",
                City = "Mikhaylovka"
            };

            yield return new ProfilesSeedModel()
            {
                Id = Guid.Parse("a728faec-b5c7-41f4-bd56-162a897ff46f"),
                Name = "Donat",
                Surname = "Latykin",
                City = "Nygda"
            };

            yield return new ProfilesSeedModel()
            {
                Id = Guid.Parse("b1091cd4-d605-480b-aa23-6f49df0e53ad"),
                Name = "Maksim",
                Surname = "Kuzmin",
                City = "Taygach"
            };
        }

        private IEnumerable<SkillSeedModel> GetSkillsData()
        {
            var random = new Random();

            var data = new List<SkillSeedModel>()
                {
                    new SkillSeedModel() { Name = "csharp", Description = "Lorem ipsum dolor sit amet."},
                    new SkillSeedModel() { Name = "javascript", Description = "Quis autem eum iur velit esse quam."},
                    new SkillSeedModel() { Name = "angular", Description = "Nemo enim sit aspernatur aut odit."},
                    new SkillSeedModel() { Name = "java", Description = "Ut enim ad minima, exercitationem ullam."},
                    new SkillSeedModel() { Name = "python", Description = "Excepteur sint in culpa id est laborum."},
                    new SkillSeedModel() { Name = "cpp", Description = "Excepteur occaecat cupida proident, suntid est."},
                    new SkillSeedModel() { Name = "php", Description = "Quis autem vel eum iure repreherit in ea quam."},
                    new SkillSeedModel() { Name = "swift", Description = "Nemo enim ipsam voptatem aut odit."},
                    new SkillSeedModel() { Name = "ruby", Description = "Excepteur sint cupitat, anim id est laborum."},
                    new SkillSeedModel() { Name = "objective_c", Description = "Ut enim ad exercitationem ullam."},
                    new SkillSeedModel() { Name = "sql", Description = "Excepteur sint occaecat prodent, est laborum."}
                };

            var length = data.Count - 1;
            var start = random.Next(0, length - 1);
            var count = length - random.Next(start + 1, length);

            return data.GetRange(start, count);
        }

        internal IEnumerable<ApplicationUser> GetApplicationUsers()
        {
            foreach (var profile in this.GetProfilesData())
            {
                yield return new ApplicationUser()
                {
                    UserName = profile.Email,
                    Email = profile.Email,
                    NormalizedUserName = profile.NormalizedEmail,
                    NormalizedEmail = profile.NormalizedEmail,
                    Id = profile.Id.ToString(),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = this.hasher.HashPassword(default!, profile.Password)
                };
            }
        }

        internal IEnumerable<GeekProfile> GetGeekProfiles()
        {
            var counter = 1;

            foreach (var profile in this.GetProfilesData())
            {
                yield return new GeekProfile()
                {
                    ProfileId = counter++,
                    Email = profile.Email,
                    UserName = profile.Id.ToString(),
                    Name = profile.Name,
                    Surname = profile.Surname,
                    City = profile.City
                };
            }
        }

        internal IEnumerable<Skill> GetSkills()
        {
            var counterSkills = 1;
            Random random = new Random();

            for (var i = 1; i <= this.GetProfilesData().Count(); i++)
            {
                var skills = this.GetSkillsData();
                foreach (var skill in skills)
                {
                    yield return new Skill()
                    {
                        SkillId = counterSkills++,
                        ProfileId = i,
                        Name = skill.Name,
                        Description = skill.Description,
                        AverageScore = random.Next(0, 5)
                    };
                }
            }
        }
    }
}
