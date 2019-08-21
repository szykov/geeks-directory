using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeeksDirectory.Data.Entities
{
    public class GeekProfile
    {
        [Key]
        public int ProfileId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string MiddleName { get; set; }

        public string City { get; set; }

        public List<Skill> Skills { get; set; }
    }
}
