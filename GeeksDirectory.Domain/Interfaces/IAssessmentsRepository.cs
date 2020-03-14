using GeeksDirectory.Domain.Entities;

namespace GeeksDirectory.Domain.Interfaces
{
    public interface IAssessmentsRepository
    {
        Assessment? Get(int profileId, int skillId, string userId);

        void Add(int profileId, int skillId, string userId, int score);

        bool Exists(int profileId, int skillId, string userId);

        void Update(int profileId, int skillId, string userId, int score);
    }
}