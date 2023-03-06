using Application.Features.Transmissions.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Pipelines.Caching;
using Freezone.Core.Application.Requests;
using Freezone.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Transmissions.Queries.GetList;

public class GetListTransmissionQuery : IRequest<GetListResponse<GetListTransmissionDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }
    

    public bool BypassCache { get; }
    public string CacheKey => "GetListTransmission";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListTransmissionQueryHandler : IRequestHandler<GetListTransmissionQuery, GetListResponse<GetListTransmissionDto>>
    {
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly IMapper _mapper;

        public GetListTransmissionQueryHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
        {
            _transmissionRepository = transmissionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTransmissionDto>> Handle(GetListTransmissionQuery request,
                                                                   CancellationToken cancellationToken)
        {
            IPaginate<Transmission> transmissions = await _transmissionRepository.GetListAsync(index: request.PageRequest.Page,
                                                                          size: request.PageRequest.PageSize);
            GetListResponse<GetListTransmissionDto> response = _mapper.Map<GetListResponse<GetListTransmissionDto>>(transmissions);
            return response;
        }
    }
}