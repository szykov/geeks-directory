#nullable disable

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeeksDirectory.Data.Entities
{
    public class GeekProfile
    {
        [Key]
        public int ProfileId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        [ForeignKey("UserName")]
        public ApplicationUser User { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string MiddleName { get; set; }

        public string City { get; set; }

        public List<Skill> Skills { get; set; }
    }
}
