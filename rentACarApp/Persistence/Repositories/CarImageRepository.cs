using Application.Services.Repositories;
using Domain.Entities;
using Freezone.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CarImageRepository : EfRepositoryBase<CarImage, BaseDbContext>, ICarImageRepository
{
    public CarImageRepository(BaseDbContext context) : base(context)
    {
    }
}