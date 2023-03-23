using Domain.Entities;
using Freezone.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IGroupTreeContentRepository : IAsyncRepository<GroupTreeContent>, IRepository<GroupTreeContent>
{
}