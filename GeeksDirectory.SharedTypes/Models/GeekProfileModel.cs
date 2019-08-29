using System.ComponentModel.DataAnnotations;

namespace GeeksDirectory.SharedTypes.Models
{
    public class GeekProfileModel
    {
        [Required]
        [StringLength(maximumLength: 255)]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 255)]
        public string Surname { get; set; }

        [StringLength(maximumLength: 255)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        public string City { get; set; }
    }
}
