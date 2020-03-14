using GeeksDirectory.Domain.Responses;

using MediatR;

namespace GeeksDirectory.Services.Queries
{
    public class GetProfileByEmailQuery : IRequest<GeekProfileResponse>
    {
        public readonly string Email;

        public GetProfileByEmailQuery(string email) => this.Email = email;
    }
}
