using GeeksDirectory.Domain.Responses;

using MediatR;

namespace GeeksDirectory.Services.Queries
{
    public class GetProfileByIdQuery : IRequest<GeekProfileResponse?> 
    {
        public readonly long ProfileId;

        public GetProfileByIdQuery(long profileId) => this.ProfileId = profileId;
    }
}
