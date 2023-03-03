using Domain.Entities;
using Freezone.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICarImageRepository : IAsyncRepository<CarImage>, IRepository<CarImage>
{
}