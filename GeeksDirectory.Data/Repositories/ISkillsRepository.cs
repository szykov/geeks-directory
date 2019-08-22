using GeeksDirectory.Data.Entities;

namespace GeeksDirectory.Data.Repositories
{
    public interface ISkillsRepository
    {
        void Add(int profileId, Skill skill);

        Skill Get(int profileId, string skillName);

        bool Exists(int profileId, string skillName);

        void SetScore(Skill skill, int score);
    }
}