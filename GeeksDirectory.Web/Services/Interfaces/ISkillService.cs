using GeeksDirectory.SharedTypes.Models;
using GeeksDirectory.SharedTypes.Responses;

using System.Threading.Tasks;

namespace GeeksDirectory.Web.Services.Interfaces
{
    public interface ISkillsService
    {
        SkillResponse Get(int profileId, string skillName);

        SkillResponse Add(int profileId, SkillModel model);

        Task EvaluateSkillAsync(int profileId, string skillName, string userEmail, int score);
    }
}