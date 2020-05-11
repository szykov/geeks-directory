#nullable disable

using GeeksDirectory.Domain.Classes;

using System;

namespace GeeksDirectory.Domain.Entities
{
    public class Assessment : Entity
    {
        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; }

        public long SkillId { get; set; }

        public Skill Skill { get; set; }

        public int Score { get; set; }
    }
}