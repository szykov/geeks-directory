using GeeksDirectory.Data.Attributes;

using System.ComponentModel.DataAnnotations;

namespace GeeksDirectory.SharedTypes.Models
{
    public class CreateGeekProfileModel : GeekProfileModel
    {
        [Required]
        [EmailAddress]
        [NoWhitespace]
        [StringLength(maximumLength: 255)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [LowerCase]
        [UpperCase]
        [NoWhitespace]
        [HasNumber]
        [SpecialCharacter(true)]
        [StringLength(maximumLength: 255, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
