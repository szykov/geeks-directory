using GeeksDirectory.Domain.Entities;

using System;

namespace GeeksDirectory.Domain.Interfaces
{
    public interface IAssessmentsRepository
    {
        Assessment? Get(long profileId, long skillId, Guid userId);

        void Add(long profileId, long skillId, Guid userId, int score);

        bool Exists(long profileId, long skillId, Guid userId);

        void Update(long profileId, long skillId, Guid userId, int score);
    }
}