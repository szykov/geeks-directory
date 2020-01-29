#pragma warning disable CA1716

using GeeksDirectory.SharedTypes.Models;
using GeeksDirectory.SharedTypes.Responses;

using System.Threading.Tasks;

namespace GeeksDirectory.Web.Services.Interfaces
{
    public interface ISkillsService
    {
        SkillResponse Get(int profileId, string skillName);

        Task<SkillResponse> AddAsync(int profileId, SkillModel model, string userEmail);

        Task<int> EvaluateSkillAsync(int profileId, string skillName, string userEmail, int score);
    }
}