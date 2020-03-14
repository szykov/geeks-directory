using MediatR;

namespace GeeksDirectory.Services.Notifications
{
    public class EvaluateSkillNotification : INotification
    {
        public readonly string UserId;
        public readonly int ProfileId;
        public readonly int skillId;
        public readonly int Score;

        public EvaluateSkillNotification(string userId, int profileId, int skillId, int score)
        {
            this.UserId = userId;
            this.ProfileId = profileId;
            this.skillId = skillId;
            this.Score = score;
        }
    }
}
