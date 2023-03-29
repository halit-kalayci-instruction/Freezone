using Application.Features.GroupTreeContentOperationClaims.Commands.Create;
using Application.Features.GroupTreeContentOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.GroupTreeContentOperationClaimService
{
    public class GroupTreeContentOperationClaimService : IGroupTreeContentOperationClaimService
    {
        private readonly IGroupTreeContentOperationClaimRepository _groupTreeContentOperationClaimRepository;
        private readonly GroupTreeContentOperationClaimBusinessRules _groupTreeContentOperationClaimBusinessRules;
        private readonly IMapper _mapper;

        public GroupTreeContentOperationClaimService(IGroupTreeContentOperationClaimRepository groupTreeContentOperationClaimRepository, GroupTreeContentOperationClaimBusinessRules groupTreeContentOperationClaimBusinessRules, IMapper mapper)
        {
            _groupTreeContentOperationClaimRepository = groupTreeContentOperationClaimRepository;
            _groupTreeContentOperationClaimBusinessRules = groupTreeContentOperationClaimBusinessRules;
            _mapper = mapper;
        }

        public async Task AddRange(List<CreateGroupTreeContentOperationClaimCommand> operationClaims)
        {
            // Business Rules
            //foreach (CreateGroupTreeContentOperationClaimCommand item in operationClaims)
            //{

            //}
            
            List<GroupTreeContentOperationClaim> operationClaimsToAdd = _mapper.Map<List<GroupTreeContentOperationClaim>>(operationClaims);
            await _groupTreeContentOperationClaimRepository.AddRangeAsync(operationClaimsToAdd);
        }
    }
}
