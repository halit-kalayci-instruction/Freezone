using Application.Features.CarImages.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.CarImages.Queries.GetById;

public class GetByIdCarImageQuery : IRequest<GetByIdCarImageResponse>
{
    public int Id { get; set; }
    
  

    public class GetByIdCarImageQueryHandler : IRequestHandler<GetByIdCarImageQuery, GetByIdCarImageResponse>
    {
        private readonly ICarImageRepository _carImageRepository;
        private readonly IMapper _mapper;

        public GetByIdCarImageQueryHandler(ICarImageRepository carImageRepository, IMapper mapper)
        {
            _carImageRepository = carImageRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCarImageResponse> Handle(GetByIdCarImageQuery request, CancellationToken cancellationToken)
        {
            CarImage? carImage = await _carImageRepository.GetAsync(b => b.Id == request.Id);

            GetByIdCarImageResponse response = _mapper.Map<GetByIdCarImageResponse>(carImage);
            return response;
        }
    }
}