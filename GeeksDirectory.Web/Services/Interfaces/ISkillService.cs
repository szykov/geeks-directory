using GeeksDirectory.SharedTypes.Models;
using GeeksDirectory.SharedTypes.Responses;

namespace GeeksDirectory.Web.Services.Interfaces
{
    public interface ISkillsService
    {
        SkillResponse Get(int profileId, string skillName);

        SkillResponse Add(int profileId, SkillModel model);

        void SetScore(int profileId, string skillName, int score);
    }
}