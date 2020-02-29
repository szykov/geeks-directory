using GeeksDirectory.Domain.Responses;

using MediatR;

namespace GeeksDirectory.Services.Queries
{
    public class GetPersonalProfileQuery : IRequest<GeekProfileResponse>
    {
        public GetPersonalProfileQuery() { }
    }
}
