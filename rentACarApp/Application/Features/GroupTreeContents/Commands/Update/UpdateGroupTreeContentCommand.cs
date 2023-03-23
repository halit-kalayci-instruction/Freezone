using Application.Features.GroupTreeContents.Constants;
using Application.Features.GroupTreeContents.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GroupTreeContents.Commands.Update;

public class UpdateGroupTreeContentCommand : IRequest<UpdatedGroupTreeContentResponse>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int ParentId { get; set; }
    public string Target { get; set; }
    public string ImgUrl { get; set; }
    public string NavigateUrl { get; set; }
    public int RowOrder { get; set; }
    public GroupTreeContentType Type { get; set; }
    

    public class UpdateGroupTreeContentCommandHandler : IRequestHandler<UpdateGroupTreeContentCommand, UpdatedGroupTreeContentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGroupTreeContentRepository _groupTreeContentRepository;
        private readonly GroupTreeContentBusinessRules _groupTreeContentBusinessRules;

        public UpdateGroupTreeContentCommandHandler(IMapper mapper, IGroupTreeContentRepository groupTreeContentRepository,
                                         GroupTreeContentBusinessRules groupTreeContentBusinessRules)
        {
            _mapper = mapper;
            _groupTreeContentRepository = groupTreeContentRepository;
            _groupTreeContentBusinessRules = groupTreeContentBusinessRules;
        }

        public async Task<UpdatedGroupTreeContentResponse> Handle(UpdateGroupTreeContentCommand request, CancellationToken cancellationToken)
        {
            GroupTreeContent groupTreeContent = _groupTreeContentRepository.Get(b => b.Id == request.Id);
            GroupTreeContent mappedGroupTreeContent = _mapper.Map(request, groupTreeContent);

            _groupTreeContentRepository.Update(mappedGroupTreeContent);

            UpdatedGroupTreeContentResponse response = _mapper.Map<UpdatedGroupTreeContentResponse>(groupTreeContent);
            return response;
        }
    }
}