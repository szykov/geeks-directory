using GeeksDirectory.Domain.Entities;

using System;

namespace GeeksDirectory.Domain.Interfaces
{
    public interface IAssessmentsRepository
    {
        Assessment? Get(long skillId, Guid userId);

        void Add(long skillId, Guid userId, int score);

        bool Exists(long skillId, Guid userId);

        void Update(long skillId, Guid userId, int score);
    }
}