using MediatR;
using System;

namespace GeeksDirectory.Services.Notifications
{
    public class EvaluateSkillNotification : INotification
    {
        public readonly Guid UserId;
        public readonly long SkillId;
        public readonly int Score;

        public EvaluateSkillNotification(Guid userId, long skillId, int score)
        {
            this.UserId = userId;
            this.SkillId = skillId;
            this.Score = score;
        }
    }
}
