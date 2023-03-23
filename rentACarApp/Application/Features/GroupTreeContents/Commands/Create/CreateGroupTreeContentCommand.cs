using Application.Features.GroupTreeContents.Constants;
using Application.Features.GroupTreeContents.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GroupTreeContents.Commands.Create;

public class CreateGroupTreeContentCommand : IRequest<CreatedGroupTreeContentResponse>
{
    public string Title { get; set; }
    public int ParentId { get; set; }
    public string Target { get; set; }
    public string ImgUrl { get; set; }
    public string NavigateUrl { get; set; }
    public int RowOrder { get; set; }
    public GroupTreeContentType Type { get; set; }

    public class CreateGroupTreeContentCommandHandler : IRequestHandler<CreateGroupTreeContentCommand, CreatedGroupTreeContentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGroupTreeContentRepository _groupTreeContentRepository;
        private readonly GroupTreeContentBusinessRules _groupTreeContentBusinessRules;

        public CreateGroupTreeContentCommandHandler(IMapper mapper, IGroupTreeContentRepository groupTreeContentRepository,
                                         GroupTreeContentBusinessRules groupTreeContentBusinessRules)
        {
            _mapper = mapper;
            _groupTreeContentRepository = groupTreeContentRepository;
            _groupTreeContentBusinessRules = groupTreeContentBusinessRules;
        }

        public async Task<CreatedGroupTreeContentResponse> Handle(CreateGroupTreeContentCommand request, CancellationToken cancellationToken)
        {
            GroupTreeContent mappedGroupTreeContent = _mapper.Map<GroupTreeContent>(request);

            _groupTreeContentRepository.Add(mappedGroupTreeContent);

            CreatedGroupTreeContentResponse response = _mapper.Map<CreatedGroupTreeContentResponse>(mappedGroupTreeContent);
            return response;
        }
    }
}