using Application.Services.Repositories;
using Domain.Entities;
using Freezone.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class GroupTreeContentOperationClaimRepository : EfRepositoryBase<GroupTreeContentOperationClaim, BaseDbContext>, IGroupTreeContentOperationClaimRepository
{
    public GroupTreeContentOperationClaimRepository(BaseDbContext context) : base(context)
    {
    }
}