using Application.Features.Cars.Constants;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Pipelines.Authorization;
using Freezone.Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Cars.Commands.Delete;

public class DeleteCarCommand : IRequest<DeletedCarResponse>, ISecuredOperation, ICacheRemoverRequest
{
    public int Id { get; set; }
    
    
        public string[] Roles => new string[] { CarsRoles.Delete };

    public bool BypassCache { get; }
    public string CacheKey => "GetListCar";

    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, DeletedCarResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        private readonly CarBusinessRules _carBusinessRules;

        public DeleteCarCommandHandler(IMapper mapper, ICarRepository carRepository,
                                         CarBusinessRules carBusinessRules)
        {
            _mapper = mapper;
            _carRepository = carRepository;
            _carBusinessRules = carBusinessRules;
        }

        public async Task<DeletedCarResponse> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            Car car = await _carRepository.GetAsync(b => b.Id == request.Id);
            await _carBusinessRules.CarMustExists(car);
            await _carBusinessRules.CarMustBeAvailable(car);
            await _carRepository.DeleteAsync(car);

            DeletedCarResponse response = _mapper.Map<DeletedCarResponse>(car);
            return response;
        }
    }
}