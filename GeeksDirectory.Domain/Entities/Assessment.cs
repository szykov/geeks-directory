#nullable disable

namespace GeeksDirectory.Domain.Entities
{
    public class Assessment
    {
        public int AssessmentId { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int SkillId { get; set; }

        public Skill Skill { get; set; }

        public int Score { get; set; }
    }
}