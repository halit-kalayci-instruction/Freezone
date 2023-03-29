using Application.Features.GroupTreeContentOperationClaims.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Requests;
using Freezone.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.GroupTreeContentOperationClaims.Queries.GetList;

public class GetListGroupTreeContentOperationClaimQuery : IRequest<GetListResponse<GetListGroupTreeContentOperationClaimDto>>
{
    public PageRequest PageRequest { get; set; }
    

    public class GetListGroupTreeContentOperationClaimQueryHandler : IRequestHandler<GetListGroupTreeContentOperationClaimQuery, GetListResponse<GetListGroupTreeContentOperationClaimDto>>
    {
        private readonly IGroupTreeContentOperationClaimRepository _groupTreeContentOperationClaimRepository;
        private readonly IMapper _mapper;

        public GetListGroupTreeContentOperationClaimQueryHandler(IGroupTreeContentOperationClaimRepository groupTreeContentOperationClaimRepository, IMapper mapper)
        {
            _groupTreeContentOperationClaimRepository = groupTreeContentOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListGroupTreeContentOperationClaimDto>> Handle(GetListGroupTreeContentOperationClaimQuery request,
                                                                   CancellationToken cancellationToken)
        {
            IPaginate<GroupTreeContentOperationClaim> groupTreeContentOperationClaims = await _groupTreeContentOperationClaimRepository.GetListAsync(index: request.PageRequest.Page,
                                                                          size: request.PageRequest.PageSize);
            GetListResponse<GetListGroupTreeContentOperationClaimDto> response = _mapper.Map<GetListResponse<GetListGroupTreeContentOperationClaimDto>>(groupTreeContentOperationClaims);
            return response;
        }
    }
}