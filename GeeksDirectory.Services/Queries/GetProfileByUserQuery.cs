using GeeksDirectory.Domain.Responses;

using MediatR;

using System;

namespace GeeksDirectory.Services.Queries
{
    public class GetProfileByUserQuery : IRequest<GeekProfileResponse>
    {
        public readonly Guid UserId;

        public GetProfileByUserQuery(Guid userId) => this.UserId = userId;
    }
}
