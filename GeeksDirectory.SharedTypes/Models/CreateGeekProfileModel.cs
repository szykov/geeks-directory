using System.ComponentModel.DataAnnotations;

namespace GeeksDirectory.SharedTypes.Models
{
    public class CreateGeekProfileModel : GeekProfileModel
    {
        [Required]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 255)]
        public string Password { get; set; }
    }
}
