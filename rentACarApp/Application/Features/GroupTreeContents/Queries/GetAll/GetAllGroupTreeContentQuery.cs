using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GroupTreeContents.Queries.GetAll
{
    public class GetAllGroupTreeContentQuery : IRequest<List<GetAllGroupTreeContentDto>>
    {
        public class GetAllGroupTreeContentQueryHandler : IRequestHandler<GetAllGroupTreeContentQuery, List<GetAllGroupTreeContentDto>>
        {
            private readonly IGroupTreeContentRepository _groupTreeContentRepository;
            private readonly IMapper _mapper;

            public GetAllGroupTreeContentQueryHandler(IGroupTreeContentRepository groupTreeContentRepository, IMapper mapper)
            {
                _groupTreeContentRepository = groupTreeContentRepository;
                _mapper = mapper;
            }

            public async Task<List<GetAllGroupTreeContentDto>> Handle(GetAllGroupTreeContentQuery request, CancellationToken cancellationToken)
            {
                IEnumerable<GroupTreeContent> allGroupTreeContents = await _groupTreeContentRepository.GetAllAsync(include:i=>i.Include(i=>i.GroupTreeContentOperationClaims).ThenInclude(i=>i.OperationClaim));

                List<GetAllGroupTreeContentDto> response = _mapper.Map<List<GetAllGroupTreeContentDto>>(allGroupTreeContents.ToList());
                return response;
            }
        }
    }
}
