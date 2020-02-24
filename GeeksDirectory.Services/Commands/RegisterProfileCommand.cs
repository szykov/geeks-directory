using FluentResults;

using GeeksDirectory.SharedTypes.Models;

using MediatR;

namespace GeeksDirectory.Services.Commands
{
    public class RegisterProfileCommand : IRequest<Result<int>>
    {
        public readonly CreateGeekProfileModel Profile;

        public RegisterProfileCommand(CreateGeekProfileModel profile)
        {
            this.Profile = profile;
        }
    }
}
