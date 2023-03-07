using Application.Features.CarImages.Commands.Delete;
using Application.Features.Cars.Constants;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Pipelines.Authorization;
using Freezone.Core.Application.Pipelines.Caching;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands.Delete
{
    public class DeleteCarCommand : IRequest<DeletedCarResponse>, ISecuredOperation, ICacheRemoverRequest
    {
        public bool BypassCache { get; set; }

        public string CacheKey => "GetCar.List";

        public string[] Roles => new[] {CarRoles.Delete};

        public int Id { get; set; }


        public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, DeletedCarResponse>
        {
            private readonly IMapper _mapper;
            private readonly ICarRepository _carRepository;
            private readonly CarBusinessRules _carBusinessRules;

            public DeleteCarCommandHandler(IMapper mapper, ICarRepository carRepository, CarBusinessRules carBusinessRules)
            {
                _mapper = mapper;
                _carRepository = carRepository;
                _carBusinessRules = carBusinessRules;
            }

            public async Task<DeletedCarResponse> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
            {
                Car car = await _carRepository.GetAsync(i => i.Id == request.Id);

                // BUSINESS RULE : Araba varlığını kontrol et
                // BUSINESS RULE : Araba stateini kontrol et
                await _carRepository.DeleteAsync(car);
                DeletedCarResponse response = _mapper.Map<DeletedCarResponse>(car);
                return response;
            }
        }
    }
}
