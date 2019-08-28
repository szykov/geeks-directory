using GeeksDirectory.Data.Attributes;

using System.ComponentModel.DataAnnotations;

namespace GeeksDirectory.SharedTypes.Models
{
    public class SkillModel
    {
        [Required]
        [NoWhitespaceValidation(ErrorMessage = "The field {0} shouldn't have white spaces.")]
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }

        [StringLength(maximumLength: 255)]
        public string Description { get; set; }
    }
}
