using GeeksDirectory.Data.Attributes;
using GeeksDirectory.SharedTypes.SchemaFilters.Models;

using Swashbuckle.AspNetCore.Annotations;

using System.ComponentModel.DataAnnotations;

namespace GeeksDirectory.SharedTypes.Models
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
        [StringLength(maximumLength: 255, MinimumLength = 6)]
        public string Password { get; set; } = default!;
    }
}
