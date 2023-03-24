using Application.Services.Repositories;
using Domain.Entities;
using Freezone.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TitleOperationClaimRepository : EfRepositoryBase<TitleOperationClaim, BaseDbContext>, ITitleOperationClaimRepository
{
    public TitleOperationClaimRepository(BaseDbContext context) : base(context)
    {
    }
}