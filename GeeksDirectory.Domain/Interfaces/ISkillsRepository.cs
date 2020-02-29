using GeeksDirectory.Domain.Entities;

namespace GeeksDirectory.Domain.Interfaces
{
    public interface ISkillsRepository
    {
        Skill? Get(int profileId, string skillName);

        bool Exists(int profileId, string skillName);

        void Add(int profileId, Skill skill);

        Skill RefreshAverageScore(int profileId, string skillName);
    }
}