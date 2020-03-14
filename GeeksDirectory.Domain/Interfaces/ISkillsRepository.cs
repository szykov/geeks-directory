using GeeksDirectory.Domain.Entities;

namespace GeeksDirectory.Domain.Interfaces
{
    public interface ISkillsRepository
    {
        Skill? Get(int profileId, int skillId);

        bool Exists(int profileId, int skillId);

        void Add(int profileId, Skill skill);

        Skill RefreshAverageScore(int profileId, int skillId);
    }
}