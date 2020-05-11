using GeeksDirectory.Domain.Entities;

namespace GeeksDirectory.Domain.Interfaces
{
    public interface ISkillsRepository
    {
        Skill? Get(long skillId);

        bool Exists(long skillId);

        void Add(long profileId, Skill skill);

        Skill RefreshAverageScore(long skillId);
    }
}