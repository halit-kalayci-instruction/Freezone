using Application.Features.GroupTreeContents.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GroupTreeContents.Queries.GetById;

public class GetByIdGroupTreeContentQuery : IRequest<GetByIdGroupTreeContentResponse>
{
    public int Id { get; set; }
    

    public class GetByIdGroupTreeContentQueryHandler : IRequestHandler<GetByIdGroupTreeContentQuery, GetByIdGroupTreeContentResponse>
    {
        private readonly IGroupTreeContentRepository _groupTreeContentRepository;
        private readonly IMapper _mapper;

        public GetByIdGroupTreeContentQueryHandler(IGroupTreeContentRepository groupTreeContentRepository, IMapper mapper)
        {
            _groupTreeContentRepository = groupTreeContentRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdGroupTreeContentResponse> Handle(GetByIdGroupTreeContentQuery request, CancellationToken cancellationToken)
        {
            GroupTreeContent? groupTreeContent = await _groupTreeContentRepository.GetAsync(b => b.Id == request.Id);

            GetByIdGroupTreeContentResponse response = _mapper.Map<GetByIdGroupTreeContentResponse>(groupTreeContent);
            return response;
        }
    }
}