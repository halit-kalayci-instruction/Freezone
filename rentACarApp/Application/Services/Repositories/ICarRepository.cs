using Domain.Entities;
using Freezone.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICarRepository : IAsyncRepository<Car>, IRepository<Car>
{
}