using GeeksDirectory.SharedTypes.Responses;

using MediatR;

namespace GeeksDirectory.Services.Queries
{
    public class GetPersonalProfileQuery : IRequest<GeekProfileResponse>
    {
        public GetPersonalProfileQuery() { }
    }
}
