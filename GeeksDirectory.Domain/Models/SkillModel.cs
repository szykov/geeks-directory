using GeeksDirectory.Domain.SchemaFilters.Models;

using Swashbuckle.AspNetCore.Annotations;

using System.ComponentModel.DataAnnotations;

namespace GeeksDirectory.Domain.Models
{
    [SwaggerSchemaFilter(typeof(SkillModelSchemaFilter))]
    public class SkillModel
    {
        [Required]
        [StringLength(maximumLength: 50)]
        public string Name { get; set; } = default!;

        [StringLength(maximumLength: 255)]
        public string? Description { get; set; }

        [Range(0, 5)]
        public int Score { get; set; }
    }
}
