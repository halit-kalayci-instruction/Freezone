using Application.Features.GroupTreeContents.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Requests;
using Freezone.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.GroupTreeContents.Queries.GetList;

public class GetListGroupTreeContentQuery : IRequest<GetListResponse<GetListGroupTreeContentDto>>
{
    public PageRequest PageRequest { get; set; }
    

    public class GetListGroupTreeContentQueryHandler : IRequestHandler<GetListGroupTreeContentQuery, GetListResponse<GetListGroupTreeContentDto>>
    {
        private readonly IGroupTreeContentRepository _groupTreeContentRepository;
        private readonly IMapper _mapper;

        public GetListGroupTreeContentQueryHandler(IGroupTreeContentRepository groupTreeContentRepository, IMapper mapper)
        {
            _groupTreeContentRepository = groupTreeContentRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListGroupTreeContentDto>> Handle(GetListGroupTreeContentQuery request,
                                                                   CancellationToken cancellationToken)
        {
            IPaginate<GroupTreeContent> groupTreeContents = await _groupTreeContentRepository.GetListAsync(index: request.PageRequest.Page,
                                                                          size: request.PageRequest.PageSize);
            GetListResponse<GetListGroupTreeContentDto> response = _mapper.Map<GetListResponse<GetListGroupTreeContentDto>>(groupTreeContents);
            return response;
        }
    }
}