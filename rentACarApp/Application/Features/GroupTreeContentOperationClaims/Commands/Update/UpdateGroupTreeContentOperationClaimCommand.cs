using Application.Features.GroupTreeContentOperationClaims.Constants;
using Application.Features.GroupTreeContentOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GroupTreeContentOperationClaims.Commands.Update;

public class UpdateGroupTreeContentOperationClaimCommand : IRequest<UpdatedGroupTreeContentOperationClaimResponse>
{
    public int Id { get; set; }
    public int GroupTreeContentId { get; set; }
    public int OperationClaimId { get; set; }
    

    public class UpdateGroupTreeContentOperationClaimCommandHandler : IRequestHandler<UpdateGroupTreeContentOperationClaimCommand, UpdatedGroupTreeContentOperationClaimResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGroupTreeContentOperationClaimRepository _groupTreeContentOperationClaimRepository;
        private readonly GroupTreeContentOperationClaimBusinessRules _groupTreeContentOperationClaimBusinessRules;

        public UpdateGroupTreeContentOperationClaimCommandHandler(IMapper mapper, IGroupTreeContentOperationClaimRepository groupTreeContentOperationClaimRepository,
                                         GroupTreeContentOperationClaimBusinessRules groupTreeContentOperationClaimBusinessRules)
        {
            _mapper = mapper;
            _groupTreeContentOperationClaimRepository = groupTreeContentOperationClaimRepository;
            _groupTreeContentOperationClaimBusinessRules = groupTreeContentOperationClaimBusinessRules;
        }

        public async Task<UpdatedGroupTreeContentOperationClaimResponse> Handle(UpdateGroupTreeContentOperationClaimCommand request, CancellationToken cancellationToken)
        {
            GroupTreeContentOperationClaim groupTreeContentOperationClaim = _groupTreeContentOperationClaimRepository.Get(b => b.Id == request.Id);
            GroupTreeContentOperationClaim mappedGroupTreeContentOperationClaim = _mapper.Map(request, groupTreeContentOperationClaim);

            _groupTreeContentOperationClaimRepository.Update(mappedGroupTreeContentOperationClaim);

            UpdatedGroupTreeContentOperationClaimResponse response = _mapper.Map<UpdatedGroupTreeContentOperationClaimResponse>(groupTreeContentOperationClaim);
            return response;
        }
    }
}