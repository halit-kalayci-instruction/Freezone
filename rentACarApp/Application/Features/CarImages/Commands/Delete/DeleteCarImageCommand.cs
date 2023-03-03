using Application.Features.CarImages.Constants;
using Application.Features.CarImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Pipelines.Authorization;
using Freezone.Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.CarImages.Commands.Delete;

public class DeleteCarImageCommand : IRequest<DeletedCarImageResponse>, ISecuredOperation, ICacheRemoverRequest
{
    public int Id { get; set; }
    
    
        public string[] Roles => new string[] { CarImagesRoles.Delete };

    public bool BypassCache { get; }
    public string CacheKey => "GetListCarImage";

    public class DeleteCarImageCommandHandler : IRequestHandler<DeleteCarImageCommand, DeletedCarImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarImageRepository _carImageRepository;
        private readonly CarImageBusinessRules _carImageBusinessRules;

        public DeleteCarImageCommandHandler(IMapper mapper, ICarImageRepository carImageRepository,
                                         CarImageBusinessRules carImageBusinessRules)
        {
            _mapper = mapper;
            _carImageRepository = carImageRepository;
            _carImageBusinessRules = carImageBusinessRules;
        }

        public async Task<DeletedCarImageResponse> Handle(DeleteCarImageCommand request, CancellationToken cancellationToken)
        {
            CarImage carImage = _carImageRepository.Get(b => b.Id == request.Id);

            _carImageRepository.Delete(carImage);

            DeletedCarImageResponse response = _mapper.Map<DeletedCarImageResponse>(carImage);
            return response;
        }
    }
}