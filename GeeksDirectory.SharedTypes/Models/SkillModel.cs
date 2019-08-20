using System.ComponentModel.DataAnnotations;

namespace GeeksDirectory.SharedTypes.Models
{
    public class SkillModel
    {
        [Required]
        [StringLength(maximumLength: 50)]
        public string Title { get; set; }

        [Required]
        [StringLength(maximumLength: 255)]
        public string Description { get; set; }

        [Required]
        [Range(0, 5)]
        public int Score { get; set; }
    }
}
