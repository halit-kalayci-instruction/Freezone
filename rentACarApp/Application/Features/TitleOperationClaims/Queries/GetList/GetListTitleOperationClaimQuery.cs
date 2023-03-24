using Application.Features.TitleOperationClaims.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Pipelines.Authorization;
using Freezone.Core.Application.Requests;
using Freezone.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.TitleOperationClaims.Queries.GetList;

public class GetListTitleOperationClaimQuery : IRequest<GetListResponse<GetListTitleOperationClaimDto>>, ISecuredOperation
{
    public PageRequest PageRequest { get; set; }
    
    
        public string[] Roles => new string[] { TitleOperationClaimsRoles.Get };

    public class GetListTitleOperationClaimQueryHandler : IRequestHandler<GetListTitleOperationClaimQuery, GetListResponse<GetListTitleOperationClaimDto>>
    {
        private readonly ITitleOperationClaimRepository _titleOperationClaimRepository;
        private readonly IMapper _mapper;

        public GetListTitleOperationClaimQueryHandler(ITitleOperationClaimRepository titleOperationClaimRepository, IMapper mapper)
        {
            _titleOperationClaimRepository = titleOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTitleOperationClaimDto>> Handle(GetListTitleOperationClaimQuery request,
                                                                   CancellationToken cancellationToken)
        {
            IPaginate<TitleOperationClaim> titleOperationClaims = await _titleOperationClaimRepository.GetListAsync(index: request.PageRequest.Page,
                                                                          size: request.PageRequest.PageSize);
            GetListResponse<GetListTitleOperationClaimDto> response = _mapper.Map<GetListResponse<GetListTitleOperationClaimDto>>(titleOperationClaims);
            return response;
        }
    }
}