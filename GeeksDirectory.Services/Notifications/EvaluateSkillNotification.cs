using GeeksDirectory.Domain.Models;

using MediatR;


namespace GeeksDirectory.Services.Notifications
{
    public class EvaluateSkillNotification : INotification
    {
        public readonly int ProfileId;
        public readonly string SkillName;
        public readonly SkillEvaluationModel SkillEvaluation;

        public EvaluateSkillNotification(int profileId, string skillName, SkillEvaluationModel skillEvaluation)
        {
            this.ProfileId = profileId;
            this.SkillName = skillName;
            this.SkillEvaluation = skillEvaluation;
        }
    }
}
