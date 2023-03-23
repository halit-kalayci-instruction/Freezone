using Domain.Entities;
using Freezone.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITitleDefinitonRepository : IAsyncRepository<TitleDefiniton>, IRepository<TitleDefiniton>
{
}