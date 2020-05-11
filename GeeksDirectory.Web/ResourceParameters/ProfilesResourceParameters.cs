using GeeksDirectory.Domain.Entities;

namespace GeeksDirectory.Web.ResourceParameters
{
    public class ProfilesResourceParameters
    {
        public int Limit { get; set; }

        public int Offset { get; set; }

        public string? OrderDirection { get; set; }

        public string? OrderBy { get; set; } = nameof(GeekProfile.Id);
    }
}
