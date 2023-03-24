using Domain.Entities;
using Freezone.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITitleDefinitonRepository : IAsyncRepository<TitleDefinition>, IRepository<TitleDefinition>
{
}