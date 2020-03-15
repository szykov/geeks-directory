using MediatR;
using System;

namespace GeeksDirectory.Services.Notifications
{
    public class EvaluateSkillNotification : INotification
    {
        public readonly Guid UserId;
        public readonly long ProfileId;
        public readonly long skillId;
        public readonly int Score;

        public EvaluateSkillNotification(Guid userId, long profileId, long skillId, int score)
        {
            this.UserId = userId;
            this.ProfileId = profileId;
            this.skillId = skillId;
            this.Score = score;
        }
    }
}
