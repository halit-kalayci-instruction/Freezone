using Application.Features.TitleOperationClaims.Constants;
using Application.Features.TitleOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.TitleOperationClaims.Commands.Update;

public class UpdateTitleOperationClaimCommand : IRequest<UpdatedTitleOperationClaimResponse>, ISecuredOperation
{
    public int Id { get; set; }
    public int TitleDefinitionId { get; set; }
    public int OperationClaimId { get; set; }
    
    
        public string[] Roles => new string[] { TitleOperationClaimsRoles.Update };

    public class UpdateTitleOperationClaimCommandHandler : IRequestHandler<UpdateTitleOperationClaimCommand, UpdatedTitleOperationClaimResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleOperationClaimRepository _titleOperationClaimRepository;
        private readonly TitleOperationClaimBusinessRules _titleOperationClaimBusinessRules;

        public UpdateTitleOperationClaimCommandHandler(IMapper mapper, ITitleOperationClaimRepository titleOperationClaimRepository,
                                         TitleOperationClaimBusinessRules titleOperationClaimBusinessRules)
        {
            _mapper = mapper;
            _titleOperationClaimRepository = titleOperationClaimRepository;
            _titleOperationClaimBusinessRules = titleOperationClaimBusinessRules;
        }

        public async Task<UpdatedTitleOperationClaimResponse> Handle(UpdateTitleOperationClaimCommand request, CancellationToken cancellationToken)
        {
            TitleOperationClaim titleOperationClaim = _titleOperationClaimRepository.Get(b => b.Id == request.Id);
            TitleOperationClaim mappedTitleOperationClaim = _mapper.Map(request, titleOperationClaim);

            _titleOperationClaimRepository.Update(mappedTitleOperationClaim);

            UpdatedTitleOperationClaimResponse response = _mapper.Map<UpdatedTitleOperationClaimResponse>(titleOperationClaim);
            return response;
        }
    }
}