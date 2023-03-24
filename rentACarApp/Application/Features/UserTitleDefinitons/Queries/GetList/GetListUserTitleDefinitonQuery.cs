using Application.Features.UserTitleDefinitons.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Pipelines.Authorization;
using Freezone.Core.Application.Requests;
using Freezone.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.UserTitleDefinitons.Queries.GetList;

public class GetListUserTitleDefinitonQuery : IRequest<GetListResponse<GetListUserTitleDefinitonDto>>, ISecuredOperation
{
    public PageRequest PageRequest { get; set; }
    
    
        public string[] Roles => new string[] { UserTitleDefinitonsRoles.Get };

    public class GetListUserTitleDefinitonQueryHandler : IRequestHandler<GetListUserTitleDefinitonQuery, GetListResponse<GetListUserTitleDefinitonDto>>
    {
        private readonly IUserTitleDefinitonRepository _userTitleDefinitonRepository;
        private readonly IMapper _mapper;

        public GetListUserTitleDefinitonQueryHandler(IUserTitleDefinitonRepository userTitleDefinitonRepository, IMapper mapper)
        {
            _userTitleDefinitonRepository = userTitleDefinitonRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserTitleDefinitonDto>> Handle(GetListUserTitleDefinitonQuery request,
                                                                   CancellationToken cancellationToken)
        {
            IPaginate<UserTitleDefiniton> userTitleDefinitons = await _userTitleDefinitonRepository.GetListAsync(index: request.PageRequest.Page,
                                                                          size: request.PageRequest.PageSize);
            GetListResponse<GetListUserTitleDefinitonDto> response = _mapper.Map<GetListResponse<GetListUserTitleDefinitonDto>>(userTitleDefinitons);
            return response;
        }
    }
}