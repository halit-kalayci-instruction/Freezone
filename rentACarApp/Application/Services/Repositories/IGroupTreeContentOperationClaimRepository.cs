using Domain.Entities;
using Freezone.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IGroupTreeContentOperationClaimRepository : IAsyncRepository<GroupTreeContentOperationClaim>, IRepository<GroupTreeContentOperationClaim>
{
}