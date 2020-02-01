using GeeksDirectory.Data.Entities;

namespace GeeksDirectory.Data.Repositories.Interfaces
{
    public interface IAssessmentsRepository
    {
        Assessment Get(int profileId, string skillName, string userName);

        void Add(int profileId, string skillName, string userName, int score);

        bool Exists(int profileId, string skillName, string userName);

        void Update(int profileId, string skillName, string userName, int score);
    }
}