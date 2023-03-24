using Domain.Entities;
using Freezone.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserTitleDefinitonRepository : IAsyncRepository<UserTitleDefiniton>, IRepository<UserTitleDefiniton>
{
}