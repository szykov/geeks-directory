#pragma warning disable CS1998

using GeeksDirectory.Domain.Entities;
using GeeksDirectory.Domain.Interfaces;
using GeeksDirectory.Services.Notifications;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using System.Threading;
using System.Threading.Tasks;

namespace GeeksDirectory.Services.Handlers
{
    public class AddOrUpdateAssesmentHandler : INotificationHandler<EvaluateSkillNotification>
    {
        private readonly HttpContext httpContext;
        private readonly IAssessmentsRepository repository;
        private readonly UserManager<ApplicationUser> userManager;

        public AddOrUpdateAssesmentHandler(
            IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager,
            IAssessmentsRepository repository)
        {
            this.httpContext = httpContextAccessor.HttpContext;
            this.userManager = userManager;
            this.repository = repository;
        }

        public async Task Handle(EvaluateSkillNotification notification, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(httpContext.User);

            if (this.repository.Exists(notification.ProfileId, notification.SkillName, user.Id))
                this.repository.Update(notification.ProfileId, notification.SkillName, user.Id, notification.SkillEvaluation.Score);
            else
                this.repository.Add(notification.ProfileId, notification.SkillName, user.Id, notification.SkillEvaluation.Score);
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
            this.repository.RefreshAverageScore(notification.ProfileId, notification.SkillName);
        }
    }
}
