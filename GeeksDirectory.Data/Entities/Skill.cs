using System.ComponentModel.DataAnnotations;

namespace GeeksDirectory.Data.Entities
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
