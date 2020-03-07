#nullable disable

using System.Collections.Generic;

namespace GeeksDirectory.Domain.Entities
{
    public class GeekProfile
    {
        public int ProfileId { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string MiddleName { get; set; }

        public string City { get; set; }

        public List<Skill> Skills { get; set; }
    }
}
