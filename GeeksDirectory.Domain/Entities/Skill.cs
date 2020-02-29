#nullable disable

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeeksDirectory.Domain.Entities
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int AverageScore { get; set; }

        public List<Assessment> Assessments { get; set; }

        public int ProfileId { get; set; }

        [ForeignKey("ProfileId")]
        public GeekProfile Profile { get; set; }
    }
}
