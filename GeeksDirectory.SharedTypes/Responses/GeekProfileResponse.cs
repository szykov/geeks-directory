using System.Collections.Generic;

namespace GeeksDirectory.SharedTypes.Responses
{
    public class GeekProfileResponse
    {
        public int ProfileId { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string MiddleName { get; set; }

        public string City { get; set; }

        public IEnumerable<SkillResponse> Skills { get; set; }
    }
}
