using GeeksDirectory.SharedTypes.Responses;

using MediatR;

namespace GeeksDirectory.Services.Queries
{
    public class GetProfileQuery : IRequest<GeekProfileResponse> 
    {
        public readonly int ProfileId;

        public GetProfileQuery(int profileId)
        {
            this.ProfileId = profileId;
        }
    }
}
