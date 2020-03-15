#nullable disable

using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;

namespace GeeksDirectory.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public GeekProfile Profile { get; set; }

        public List<Assessment> Assessments { get; set; }
    }
}
