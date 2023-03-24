using Application.Features.TitleOperationClaims.Constants;
using Application.Features.TitleOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.TitleOperationClaims.Commands.Create;

public class CreateTitleOperationClaimCommand : IRequest<CreatedTitleOperationClaimResponse>, ISecuredOperation
{
    public int TitleDefinitionId { get; set; }
    public int OperationClaimId { get; set; }

    public string[] Roles => new[] { TitleOperationClaimsRoles.Create };

    public class CreateTitleOperationClaimCommandHandler : IRequestHandler<CreateTitleOperationClaimCommand, CreatedTitleOperationClaimResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleOperationClaimRepository _titleOperationClaimRepository;
        private readonly TitleOperationClaimBusinessRules _titleOperationClaimBusinessRules;

        public CreateTitleOperationClaimCommandHandler(IMapper mapper, ITitleOperationClaimRepository titleOperationClaimRepository,
                                         TitleOperationClaimBusinessRules titleOperationClaimBusinessRules)
        {
            _mapper = mapper;
            _titleOperationClaimRepository = titleOperationClaimRepository;
            _titleOperationClaimBusinessRules = titleOperationClaimBusinessRules;
        }

        public async Task<CreatedTitleOperationClaimResponse> Handle(CreateTitleOperationClaimCommand request, CancellationToken cancellationToken)
        {
            TitleOperationClaim mappedTitleOperationClaim = _mapper.Map<TitleOperationClaim>(request);

            _titleOperationClaimRepository.Add(mappedTitleOperationClaim);

            CreatedTitleOperationClaimResponse response = _mapper.Map<CreatedTitleOperationClaimResponse>(mappedTitleOperationClaim);
            return response;
        }
    }
}