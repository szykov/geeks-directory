#pragma warning disable CS1998

using GeeksDirectory.Domain.Interfaces;
using GeeksDirectory.Services.Notifications;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace GeeksDirectory.Services.Handlers
{
    public class AddOrUpdateAssesmentHandler : INotificationHandler<EvaluateSkillNotification>
    {
        private readonly IAssessmentsRepository repository;

        public AddOrUpdateAssesmentHandler(IAssessmentsRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(EvaluateSkillNotification notification, CancellationToken cancellationToken)
        {
            if (this.repository.Exists(notification.ProfileId, notification.skillId, notification.UserId))
                this.repository.Update(notification.ProfileId, notification.skillId, notification.UserId, notification.Score);
            else
                this.repository.Add(notification.ProfileId, notification.skillId, notification.UserId, notification.Score);
        }
    }

    public class RefreshAverageScoreHandler : INotificationHandler<EvaluateSkillNotification>
    {
        private readonly ISkillsRepository repository;

        public RefreshAverageScoreHandler(ISkillsRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(EvaluateSkillNotification notification, CancellationToken cancellationToken)
        {
            this.repository.RefreshAverageScore(notification.ProfileId, notification.skillId);
        }
    }
}
