using GeeksDirectory.Domain.Attributes;
using GeeksDirectory.Domain.SchemaFilters.Models;

using Swashbuckle.AspNetCore.Annotations;

using System.ComponentModel.DataAnnotations;

namespace GeeksDirectory.Domain.Models
{
    [SwaggerSchemaFilter(typeof(CreateGeekProfileModelSchemaFilter))]
    public class CreateGeekProfileModel : GeekProfileModel
    {
        [Required]
        [EmailAddress]
        [NoWhitespace]
        [StringLength(maximumLength: 255)]
        public string Email { get; set; } = default!;

        [Required]
        [DataType(DataType.Password)]
        [LowerCase]
        [UpperCase]
        [NoWhitespace]
        [HasNumber]
        [SpecialCharacter(true)]
        [StringLength(maximumLength: 255, MinimumLength = 8)]
        public string Password { get; set; } = default!;
    }
}
