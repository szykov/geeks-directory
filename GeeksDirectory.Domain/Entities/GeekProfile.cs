#nullable disable

using GeeksDirectory.Domain.Classes;

using System.Collections.Generic;
using System;

namespace GeeksDirectory.Domain.Entities
{
    public class GeekProfile : Entity
    {
        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string MiddleName { get; set; }

        public string City { get; set; }

        public List<Skill> Skills { get; set; }
    }
}
