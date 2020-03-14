using GeeksDirectory.Domain.Responses;

using MediatR;

namespace GeeksDirectory.Services.Queries
{
    public class GetProfileByIdQuery : IRequest<GeekProfileResponse?> 
    {
        public readonly int ProfileId;

        public GetProfileByIdQuery(int profileId) => this.ProfileId = profileId;
    }
}
