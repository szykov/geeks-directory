using GeeksDirectory.Domain.Entities;

namespace GeeksDirectory.Domain.Interfaces
{
    public interface ISkillsRepository
    {
        Skill? Get(long profileId, long skillId);

        bool Exists(long profileId, long skillId);

        void Add(long profileId, Skill skill);

        Skill RefreshAverageScore(long profileId, long skillId);
    }
}