using Application.Features.TitleDefinitons.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Requests;
using Freezone.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.TitleDefinitons.Queries.GetList;

public class GetListTitleDefinitonQuery : IRequest<GetListResponse<GetListTitleDefinitonDto>>
{
    public PageRequest PageRequest { get; set; }
    

    public class GetListTitleDefinitonQueryHandler : IRequestHandler<GetListTitleDefinitonQuery, GetListResponse<GetListTitleDefinitonDto>>
    {
        private readonly ITitleDefinitonRepository _titleDefinitonRepository;
        private readonly IMapper _mapper;

        public GetListTitleDefinitonQueryHandler(ITitleDefinitonRepository titleDefinitonRepository, IMapper mapper)
        {
            _titleDefinitonRepository = titleDefinitonRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTitleDefinitonDto>> Handle(GetListTitleDefinitonQuery request,
                                                                   CancellationToken cancellationToken)
        {
            IPaginate<TitleDefiniton> titleDefinitons = await _titleDefinitonRepository.GetListAsync(index: request.PageRequest.Page,
                                                                          size: request.PageRequest.PageSize);
            GetListResponse<GetListTitleDefinitonDto> response = _mapper.Map<GetListResponse<GetListTitleDefinitonDto>>(titleDefinitons);
            return response;
        }
    }
}