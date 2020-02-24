using FluentResults;

using GeeksDirectory.SharedTypes.Models;

using MediatR;

namespace GeeksDirectory.Services.Commands
{
    public class UpdatePersonalProfileCommand : IRequest<Result<int>>
    {
        public readonly GeekProfileModel Profile;
        public UpdatePersonalProfileCommand(GeekProfileModel profile)
        {
            this.Profile = profile;
        }
    }
}
