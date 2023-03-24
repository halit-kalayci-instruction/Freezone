using Domain.Entities;
using Freezone.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITitleOperationClaimRepository : IAsyncRepository<TitleOperationClaim>, IRepository<TitleOperationClaim>
{
}