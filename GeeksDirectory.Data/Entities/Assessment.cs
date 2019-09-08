using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeeksDirectory.Data.Entities
{
    public class Assessment
    {
        [Key]
        public int AssessmentId { get; set; }

        public string UserName { get; set; }

        [ForeignKey("UserName")]
        public ApplicationUser User { get; set; }

        public int SkillId { get; set; }

        [ForeignKey("SkillId")]
        public Skill Skill { get; set; }

        public int Score { get; set; }
    }
}