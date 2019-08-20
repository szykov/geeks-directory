using GeeksDirectory.SharedTypes.Models;

namespace GeeksDirectory.Web.Services.Interfaces
{
    public interface ISkillsService
    {
        void Add(int profileId, SkillModel skill);

        void SetScore(int profileId, string skillName, int scoreId);
    }
}