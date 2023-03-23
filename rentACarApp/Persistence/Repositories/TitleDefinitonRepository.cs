using Application.Services.Repositories;
using Domain.Entities;
using Freezone.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TitleDefinitonRepository : EfRepositoryBase<TitleDefiniton, BaseDbContext>, ITitleDefinitonRepository
{
    public TitleDefinitonRepository(BaseDbContext context) : base(context)
    {
    }
}