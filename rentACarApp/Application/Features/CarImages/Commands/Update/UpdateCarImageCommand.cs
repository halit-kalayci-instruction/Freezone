using Application.Features.CarImages.Constants;
using Application.Features.CarImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Pipelines.Authorization;
using Freezone.Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.CarImages.Commands.Update;

public class UpdateCarImageCommand : IRequest<UpdatedCarImageResponse>, ISecuredOperation, ICacheRemoverRequest
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public string Path { get; set; }
    
    
        public string[] Roles => new string[] { CarImagesRoles.Update };

    public bool BypassCache { get; }
    public string CacheKey => "GetListCarImage";

    public class UpdateCarImageCommandHandler : IRequestHandler<UpdateCarImageCommand, UpdatedCarImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarImageRepository _carImageRepository;
        private readonly CarImageBusinessRules _carImageBusinessRules;

        public UpdateCarImageCommandHandler(IMapper mapper, ICarImageRepository carImageRepository,
                                         CarImageBusinessRules carImageBusinessRules)
        {
            _mapper = mapper;
            _carImageRepository = carImageRepository;
            _carImageBusinessRules = carImageBusinessRules;
        }

        public async Task<UpdatedCarImageResponse> Handle(UpdateCarImageCommand request, CancellationToken cancellationToken)
        {
            CarImage carImage = _carImageRepository.Get(b => b.Id == request.Id);
            CarImage mappedCarImage = _mapper.Map(request, carImage);

            _carImageRepository.Update(mappedCarImage);

            UpdatedCarImageResponse response = _mapper.Map<UpdatedCarImageResponse>(carImage);
            return response;
        }
    }
}