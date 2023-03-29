using Application.Features.GroupTreeContentOperationClaims.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GroupTreeContentOperationClaims.Queries.GetById;

public class GetByIdGroupTreeContentOperationClaimQuery : IRequest<GetByIdGroupTreeContentOperationClaimResponse>
{
    public int Id { get; set; }
    

    public class GetByIdGroupTreeContentOperationClaimQueryHandler : IRequestHandler<GetByIdGroupTreeContentOperationClaimQuery, GetByIdGroupTreeContentOperationClaimResponse>
    {
        private readonly IGroupTreeContentOperationClaimRepository _groupTreeContentOperationClaimRepository;
        private readonly IMapper _mapper;

        public GetByIdGroupTreeContentOperationClaimQueryHandler(IGroupTreeContentOperationClaimRepository groupTreeContentOperationClaimRepository, IMapper mapper)
        {
            _groupTreeContentOperationClaimRepository = groupTreeContentOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdGroupTreeContentOperationClaimResponse> Handle(GetByIdGroupTreeContentOperationClaimQuery request, CancellationToken cancellationToken)
        {
            GroupTreeContentOperationClaim? groupTreeContentOperationClaim = await _groupTreeContentOperationClaimRepository.GetAsync(b => b.Id == request.Id);

            GetByIdGroupTreeContentOperationClaimResponse response = _mapper.Map<GetByIdGroupTreeContentOperationClaimResponse>(groupTreeContentOperationClaim);
            return response;
        }
    }
}