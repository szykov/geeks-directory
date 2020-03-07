using GeeksDirectory.Domain.Entities;

namespace GeeksDirectory.Domain.Interfaces
{
    public interface IAssessmentsRepository
    {
        Assessment? Get(int profileId, string skillName, string userId);

        void Add(int profileId, string skillName, string userId, int score);

        bool Exists(int profileId, string skillName, string userId);

        void Update(int profileId, string skillName, string userId, int score);
    }
}