using FluentResults;

using GeeksDirectory.Domain.Models;

using MediatR;

namespace GeeksDirectory.Services.Commands
{
    public class UpdateProfileCommand : IRequest<Result<int>>
    {
        public readonly GeekProfileModel Profile;
        public readonly int ProfileId;

        public UpdateProfileCommand(GeekProfileModel profile, int profileId) =>
            (this.Profile, this.ProfileId) = (profile, profileId);
    }
}
