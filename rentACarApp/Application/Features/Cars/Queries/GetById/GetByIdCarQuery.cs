using Application.Features.Cars.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Pipelines.Authorization;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cars.Queries.GetById;

public class GetByIdCarQuery : IRequest<GetByIdCarResponse>
{
    public int Id { get; set; }
    
    

    public class GetByIdCarQueryHandler : IRequestHandler<GetByIdCarQuery, GetByIdCarResponse>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetByIdCarQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCarResponse> Handle(GetByIdCarQuery request, CancellationToken cancellationToken)
        {
            Car? car = await _carRepository.GetAsync(b => b.Id == request.Id,include: i=>i.Include(c=>c.Model));

            GetByIdCarResponse response = _mapper.Map<GetByIdCarResponse>(car);
            return response;
        }
    }
}