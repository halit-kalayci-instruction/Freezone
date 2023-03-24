using Application.Features.TitleOperationClaims.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.TitleOperationClaims.Queries.GetById;

public class GetByIdTitleOperationClaimQuery : IRequest<GetByIdTitleOperationClaimResponse>, ISecuredOperation
{
    public int Id { get; set; }
    
    
        public string[] Roles => new string[] { TitleOperationClaimsRoles.Get };

    public class GetByIdTitleOperationClaimQueryHandler : IRequestHandler<GetByIdTitleOperationClaimQuery, GetByIdTitleOperationClaimResponse>
    {
        private readonly ITitleOperationClaimRepository _titleOperationClaimRepository;
        private readonly IMapper _mapper;

        public GetByIdTitleOperationClaimQueryHandler(ITitleOperationClaimRepository titleOperationClaimRepository, IMapper mapper)
        {
            _titleOperationClaimRepository = titleOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdTitleOperationClaimResponse> Handle(GetByIdTitleOperationClaimQuery request, CancellationToken cancellationToken)
        {
            TitleOperationClaim? titleOperationClaim = await _titleOperationClaimRepository.GetAsync(b => b.Id == request.Id);

            GetByIdTitleOperationClaimResponse response = _mapper.Map<GetByIdTitleOperationClaimResponse>(titleOperationClaim);
            return response;
        }
    }
}