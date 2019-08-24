using GeeksDirectory.Data.Attributes;

using System.ComponentModel.DataAnnotations;

namespace GeeksDirectory.SharedTypes.Models
{
    public class CreateGeekProfileModel : GeekProfileModel
    {
        [Required]
        [EmailAddress]
        [NoWhitespaceValidation(ErrorMessage = "The field {0} shouldn't have white spaces.")]
        [StringLength(maximumLength: 255)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 255)]
        public string Password { get; set; }
    }
}
