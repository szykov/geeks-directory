using GeeksDirectory.Data.Attributes;

using System.ComponentModel.DataAnnotations;

namespace GeeksDirectory.SharedTypes.Models
{
    public class SkillModel
    {
        [Required]
        [NoWhitespace]
        [SpecialCharacter(false)]
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }

        [StringLength(maximumLength: 255)]
        public string Description { get; set; }

        [Range(0, 5)]
        public int Score { get; set; }
    }
}
