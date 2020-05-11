using FluentResults;

using GeeksDirectory.Domain.Models;

using MediatR;

namespace GeeksDirectory.Services.Commands
{
    public class UpdateProfileCommand : IRequest<Result<long>>
    {
        public readonly GeekProfileModel Profile;
        public readonly long ProfileId;

        public UpdateProfileCommand(GeekProfileModel profile, long profileId) =>
            (this.Profile, this.ProfileId) = (profile, profileId);
    }
}
