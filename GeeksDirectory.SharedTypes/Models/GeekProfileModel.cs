using GeeksDirectory.SharedTypes.SchemaFilters.Models;

using Swashbuckle.AspNetCore.Annotations;

using System.ComponentModel.DataAnnotations;

namespace GeeksDirectory.SharedTypes.Models
{
    [SwaggerSchemaFilter(typeof(GeekProfileModelSchemaFilter))]
    public class GeekProfileModel
    {
        [Required]
        [StringLength(maximumLength: 255)]
        public string Name { get; set; } = default!;

        [Required]
        [StringLength(maximumLength: 255)]
        public string Surname { get; set; } = default!;

        [StringLength(maximumLength: 255)]
        public string? MiddleName { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        public string City { get; set; } = default!;
    }
}
