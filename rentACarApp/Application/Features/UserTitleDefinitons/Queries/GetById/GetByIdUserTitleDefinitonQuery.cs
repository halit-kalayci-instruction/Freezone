using Application.Features.UserTitleDefinitons.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.UserTitleDefinitons.Queries.GetById;

public class GetByIdUserTitleDefinitonQuery : IRequest<GetByIdUserTitleDefinitonResponse>, ISecuredOperation
{
    public int Id { get; set; }
    
    
        public string[] Roles => new string[] { UserTitleDefinitonsRoles.Get };

    public class GetByIdUserTitleDefinitonQueryHandler : IRequestHandler<GetByIdUserTitleDefinitonQuery, GetByIdUserTitleDefinitonResponse>
    {
        private readonly IUserTitleDefinitonRepository _userTitleDefinitonRepository;
        private readonly IMapper _mapper;

        public GetByIdUserTitleDefinitonQueryHandler(IUserTitleDefinitonRepository userTitleDefinitonRepository, IMapper mapper)
        {
            _userTitleDefinitonRepository = userTitleDefinitonRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdUserTitleDefinitonResponse> Handle(GetByIdUserTitleDefinitonQuery request, CancellationToken cancellationToken)
        {
            UserTitleDefiniton? userTitleDefiniton = await _userTitleDefinitonRepository.GetAsync(b => b.Id == request.Id);

            GetByIdUserTitleDefinitonResponse response = _mapper.Map<GetByIdUserTitleDefinitonResponse>(userTitleDefiniton);
            return response;
        }
    }
}