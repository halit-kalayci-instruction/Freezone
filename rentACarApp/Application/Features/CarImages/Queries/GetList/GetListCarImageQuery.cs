using Application.Features.CarImages.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Pipelines.Authorization;
using Freezone.Core.Application.Pipelines.Caching;
using Freezone.Core.Application.Requests;
using Freezone.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.CarImages.Queries.GetList;

public class GetListCarImageQuery : IRequest<GetListResponse<GetListCarImageDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }
    

    public bool BypassCache { get; }
    public string CacheKey => "GetListCarImage";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCarImageQueryHandler : IRequestHandler<GetListCarImageQuery, GetListResponse<GetListCarImageDto>>
    {
        private readonly ICarImageRepository _carImageRepository;
        private readonly IMapper _mapper;

        public GetListCarImageQueryHandler(ICarImageRepository carImageRepository, IMapper mapper)
        {
            _carImageRepository = carImageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCarImageDto>> Handle(GetListCarImageQuery request,
                                                                   CancellationToken cancellationToken)
        {
            IPaginate<CarImage> carImages = await _carImageRepository.GetListAsync(index: request.PageRequest.Page,
                                                                          size: request.PageRequest.PageSize);
            GetListResponse<GetListCarImageDto> response = _mapper.Map<GetListResponse<GetListCarImageDto>>(carImages);
            return response;
        }
    }
}