using Application.Features.GroupTreeContentOperationClaims.Constants;
using Application.Features.GroupTreeContentOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GroupTreeContentOperationClaims.Commands.Delete;

public class DeleteGroupTreeContentOperationClaimCommand : IRequest<DeletedGroupTreeContentOperationClaimResponse>
{
    public int Id { get; set; }
    

    public class DeleteGroupTreeContentOperationClaimCommandHandler : IRequestHandler<DeleteGroupTreeContentOperationClaimCommand, DeletedGroupTreeContentOperationClaimResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGroupTreeContentOperationClaimRepository _groupTreeContentOperationClaimRepository;
        private readonly GroupTreeContentOperationClaimBusinessRules _groupTreeContentOperationClaimBusinessRules;

        public DeleteGroupTreeContentOperationClaimCommandHandler(IMapper mapper, IGroupTreeContentOperationClaimRepository groupTreeContentOperationClaimRepository,
                                         GroupTreeContentOperationClaimBusinessRules groupTreeContentOperationClaimBusinessRules)
        {
            _mapper = mapper;
            _groupTreeContentOperationClaimRepository = groupTreeContentOperationClaimRepository;
            _groupTreeContentOperationClaimBusinessRules = groupTreeContentOperationClaimBusinessRules;
        }

        public async Task<DeletedGroupTreeContentOperationClaimResponse> Handle(DeleteGroupTreeContentOperationClaimCommand request, CancellationToken cancellationToken)
        {
            GroupTreeContentOperationClaim groupTreeContentOperationClaim = _groupTreeContentOperationClaimRepository.Get(b => b.Id == request.Id);

            _groupTreeContentOperationClaimRepository.Delete(groupTreeContentOperationClaim);

            DeletedGroupTreeContentOperationClaimResponse response = _mapper.Map<DeletedGroupTreeContentOperationClaimResponse>(groupTreeContentOperationClaim);
            return response;
        }
    }
}