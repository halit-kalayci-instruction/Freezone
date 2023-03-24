using Application.Features.TitleOperationClaims.Constants;
using Application.Features.TitleOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.TitleOperationClaims.Commands.Delete;

public class DeleteTitleOperationClaimCommand : IRequest<DeletedTitleOperationClaimResponse>, ISecuredOperation
{
    public int Id { get; set; }
    
    
        public string[] Roles => new string[] { TitleOperationClaimsRoles.Delete };

    public class DeleteTitleOperationClaimCommandHandler : IRequestHandler<DeleteTitleOperationClaimCommand, DeletedTitleOperationClaimResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleOperationClaimRepository _titleOperationClaimRepository;
        private readonly TitleOperationClaimBusinessRules _titleOperationClaimBusinessRules;

        public DeleteTitleOperationClaimCommandHandler(IMapper mapper, ITitleOperationClaimRepository titleOperationClaimRepository,
                                         TitleOperationClaimBusinessRules titleOperationClaimBusinessRules)
        {
            _mapper = mapper;
            _titleOperationClaimRepository = titleOperationClaimRepository;
            _titleOperationClaimBusinessRules = titleOperationClaimBusinessRules;
        }

        public async Task<DeletedTitleOperationClaimResponse> Handle(DeleteTitleOperationClaimCommand request, CancellationToken cancellationToken)
        {
            TitleOperationClaim titleOperationClaim = _titleOperationClaimRepository.Get(b => b.Id == request.Id);

            _titleOperationClaimRepository.Delete(titleOperationClaim);

            DeletedTitleOperationClaimResponse response = _mapper.Map<DeletedTitleOperationClaimResponse>(titleOperationClaim);
            return response;
        }
    }
}