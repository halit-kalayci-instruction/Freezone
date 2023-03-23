using Application.Services.Repositories;
using Domain.Entities;
using Freezone.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class GroupTreeContentRepository : EfRepositoryBase<GroupTreeContent, BaseDbContext>, IGroupTreeContentRepository
{
    public GroupTreeContentRepository(BaseDbContext context) : base(context)
    {
    }
}