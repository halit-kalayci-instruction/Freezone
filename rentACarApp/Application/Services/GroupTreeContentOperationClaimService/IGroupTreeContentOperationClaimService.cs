using Application.Features.GroupTreeContentOperationClaims.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.GroupTreeContentOperationClaimService
{
    public interface IGroupTreeContentOperationClaimService
    {
        Task AddRange(List<CreateGroupTreeContentOperationClaimCommand> operationClaims);
    }
}
