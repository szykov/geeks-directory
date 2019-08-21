using GeeksDirectory.SharedTypes.Models;
using GeeksDirectory.SharedTypes.Responses;

namespace GeeksDirectory.Web.Services.Interfaces
{
    public interface ISkillsService
    {
        SkillResponse Add(int profileId, SkillModel model);

        void SetScore(int profileId, string skillTitle, int scoreId);
    }
}