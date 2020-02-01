using GeeksDirectory.Data.Entities;

namespace GeeksDirectory.Data.Repositories.Interfaces
{
    public interface ISkillsRepository
    {
        void Add(int profileId, Skill skill);

        Skill Get(int profileId, string skillName);

        bool Exists(int profileId, string skillName);

        Skill RefreshAverageScore(int profileId, string skillName);
    }
}