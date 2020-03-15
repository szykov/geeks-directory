#nullable disable

using GeeksDirectory.Domain.Classes;

using System.Collections.Generic;

namespace GeeksDirectory.Domain.Entities
{
    public class Skill : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int AverageScore { get; set; }

        public List<Assessment> Assessments { get; set; }

        public long ProfileId { get; set; }

        public GeekProfile Profile { get; set; }
    }
}
