#pragma warning disable CS1998

using AutoMapper;
using GeeksDirectory.Domain.Interfaces;
using GeeksDirectory.Services.Mappings;
using GeeksDirectory.Services.Queries;
using GeeksDirectory.Domain.Responses;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace GeeksDirectory.Services.Handlers
{
    public class GetSkillHandler : IRequestHandler<GetSkillQuery, SkillResponse?>
    {
        private readonly ISkillsRepository repository;
        private readonly IMapper mapper;

        public GetSkillHandler(ISkillsRepository repository, IMapperService mapperService)
        {
            this.repository = repository;
            this.mapper = mapperService.GetDataMapper();
        }

        public async Task<SkillResponse?> Handle(GetSkillQuery request, CancellationToken cancellationToken)
        {
            var skill = this.repository.Get(request.ProfileId, request.SkillName);
            return this.mapper.Map<SkillResponse?>(skill);
        }
    }
}
