using Application.Services.Repositories;
using Domain.Entities;
using Freezone.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserTitleDefinitonRepository : EfRepositoryBase<UserTitleDefiniton, BaseDbContext>, IUserTitleDefinitonRepository
{
    public UserTitleDefinitonRepository(BaseDbContext context) : base(context)
    {
    }
}