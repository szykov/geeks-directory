using FluentResults;

using GeeksDirectory.Domain.Models;

using MediatR;

namespace GeeksDirectory.Services.Commands
{
    public class RegisterProfileCommand : IRequest<Result<long>>
    {
        public readonly CreateGeekProfileModel Profile;

        public RegisterProfileCommand(CreateGeekProfileModel profile) => this.Profile = profile;
    }
}
