using GeeksDirectory.Data.Attributes;
using GeeksDirectory.SharedTypes.SchemaFilters.Models;

using Swashbuckle.AspNetCore.Annotations;

using System.ComponentModel.DataAnnotations;

namespace GeeksDirectory.SharedTypes.Models
{
    [SwaggerSchemaFilter(typeof(SkillModelSchemaFilter))]
    public class SkillModel
    {
        [Required]
        [NoWhitespace]
        [SpecialCharacter(false)]
        [StringLength(maximumLength: 50)]
        public string Name { get; set; } = default!;

        [StringLength(maximumLength: 255)]
        public string? Description { get; set; }

        [Range(0, 5)]
        public int Score { get; set; }
    }
}
