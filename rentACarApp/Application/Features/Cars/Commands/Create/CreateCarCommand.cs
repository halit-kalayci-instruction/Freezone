using Application.Features.Cars.Constants;
using Application.Features.Cars.Rules;
using Application.Hubs;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Freezone.Core.Application.Pipelines.Authorization;
using Freezone.Core.Application.Pipelines.Caching;
using MediatR;
using Microsoft.AspNet.SignalR;

namespace Application.Features.Cars.Commands.Create;

public class CreateCarCommand : IRequest<CreatedCarResponse>, ISecuredOperation, ICacheRemoverRequest
{
    public int ModelId { get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }
    public CarState CarState { get; set; }
    public short MinFindeksCreditRate { get; set; }

    public string[] Roles => new[] { CarsRoles.Create };

    public bool BypassCache { get; }
    public string CacheKey => "GetListCar";

    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CreatedCarResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        private readonly CarBusinessRules _carBusinessRules;
        private readonly IHubContext<ChatHub> _hubContext;

        public CreateCarCommandHandler(IMapper mapper, ICarRepository carRepository,
                                         CarBusinessRules carBusinessRules, IHubContext<ChatHub> hubContext)
        {
            _mapper = mapper;
            _carRepository = carRepository;
            _carBusinessRules = carBusinessRules;
            _hubContext = hubContext;
        }

        public async Task<CreatedCarResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            Car mappedCar = _mapper.Map<Car>(request);

            _carRepository.Add(mappedCar);
            await _hubContext.Clients.All.SendNotificationAsync("Sisteme yeni bir araba eklendi.");
            CreatedCarResponse response = _mapper.Map<CreatedCarResponse>(mappedCar);
            return response;
        }
    }
}