using Application.Features.TitleDefinitons.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TitleDefinitons.Queries.GetById;

public class GetByIdTitleDefinitonQuery : IRequest<GetByIdTitleDefinitonResponse>
{
    public int Id { get; set; }
    

    public class GetByIdTitleDefinitonQueryHandler : IRequestHandler<GetByIdTitleDefinitonQuery, GetByIdTitleDefinitonResponse>
    {
        private readonly ITitleDefinitonRepository _titleDefinitonRepository;
        private readonly IMapper _mapper;

        public GetByIdTitleDefinitonQueryHandler(ITitleDefinitonRepository titleDefinitonRepository, IMapper mapper)
        {
            _titleDefinitonRepository = titleDefinitonRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdTitleDefinitonResponse> Handle(GetByIdTitleDefinitonQuery request, CancellationToken cancellationToken)
        {
            TitleDefiniton? titleDefiniton = await _titleDefinitonRepository.GetAsync(b => b.Id == request.Id);

            GetByIdTitleDefinitonResponse response = _mapper.Map<GetByIdTitleDefinitonResponse>(titleDefiniton);
            return response;
        }
    }
}