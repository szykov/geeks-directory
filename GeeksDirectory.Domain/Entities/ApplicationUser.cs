#nullable disable

using Microsoft.AspNetCore.Identity;

using System.Collections.Generic;

namespace GeeksDirectory.Domain.Entities
{
    public class ApplicationUser : IdentityUser 
    {
        public GeekProfile Profile { get; set; }

        public List<Assessment> Assessments { get; set; }
    }
}
