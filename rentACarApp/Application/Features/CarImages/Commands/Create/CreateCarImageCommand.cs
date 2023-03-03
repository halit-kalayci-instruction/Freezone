using Application.Features.CarImages.Constants;
using Application.Features.CarImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Pipelines.Authorization;
using Freezone.Core.Application.Pipelines.Caching;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.CarImages.Commands.Create;

public class CreateCarImageCommand : IRequest<CreatedCarImageResponse>, ISecuredOperation, ICacheRemoverRequest
{
    public int CarId { get; set; }
    public string Path { get; set; }

    public string[] Roles => new[] { CarImagesRoles.Create };

    public bool BypassCache { get; }
    public string CacheKey => "GetListCarImage";

    public class CreateCarImageCommandHandler : IRequestHandler<CreateCarImageCommand, CreatedCarImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarImageRepository _carImageRepository;
        private readonly CarImageBusinessRules _carImageBusinessRules;

        public CreateCarImageCommandHandler(IMapper mapper, ICarImageRepository carImageRepository,
                                         CarImageBusinessRules carImageBusinessRules)
        {
            _mapper = mapper;
            _carImageRepository = carImageRepository;
            _carImageBusinessRules = carImageBusinessRules;
        }

        public async Task<CreatedCarImageResponse> Handle(CreateCarImageCommand request, CancellationToken cancellationToken)
        {
            CarImage mappedCarImage = _mapper.Map<CarImage>(request);

            _carImageRepository.Add(mappedCarImage);

            CreatedCarImageResponse response = _mapper.Map<CreatedCarImageResponse>(mappedCarImage);
            return response;
        }
    }
}