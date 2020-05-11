using GeeksDirectory.Domain.Entities;

using MediatR;

namespace GeeksDirectory.Services.Queries
{
    public class GetCurrentUserQuery : IRequest<ApplicationUser>
    {
        public GetCurrentUserQuery() { }
    }
}
