using Application.Features.GroupTreeContentOperationClaims.Constants;
using Application.Features.GroupTreeContentOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GroupTreeContentOperationClaims.Commands.Create;

public class CreateGroupTreeContentOperationClaimCommand : IRequest<CreatedGroupTreeContentOperationClaimResponse>
{
    public int GroupTreeContentId { get; set; }
    public int OperationClaimId { get; set; }

    public class CreateGroupTreeContentOperationClaimCommandHandler : IRequestHandler<CreateGroupTreeContentOperationClaimCommand, CreatedGroupTreeContentOperationClaimResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGroupTreeContentOperationClaimRepository _groupTreeContentOperationClaimRepository;
        private readonly GroupTreeContentOperationClaimBusinessRules _groupTreeContentOperationClaimBusinessRules;

        public CreateGroupTreeContentOperationClaimCommandHandler(IMapper mapper, IGroupTreeContentOperationClaimRepository groupTreeContentOperationClaimRepository,
                                         GroupTreeContentOperationClaimBusinessRules groupTreeContentOperationClaimBusinessRules)
        {
            _mapper = mapper;
            _groupTreeContentOperationClaimRepository = groupTreeContentOperationClaimRepository;
            _groupTreeContentOperationClaimBusinessRules = groupTreeContentOperationClaimBusinessRules;
        }

        public async Task<CreatedGroupTreeContentOperationClaimResponse> Handle(CreateGroupTreeContentOperationClaimCommand request, CancellationToken cancellationToken)
        {
            GroupTreeContentOperationClaim mappedGroupTreeContentOperationClaim = _mapper.Map<GroupTreeContentOperationClaim>(request);

            _groupTreeContentOperationClaimRepository.Add(mappedGroupTreeContentOperationClaim);

            CreatedGroupTreeContentOperationClaimResponse response = _mapper.Map<CreatedGroupTreeContentOperationClaimResponse>(mappedGroupTreeContentOperationClaim);
            return response;
        }
    }
}