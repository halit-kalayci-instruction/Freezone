using Application.Features.GroupTreeContents.Constants;
using Application.Features.GroupTreeContents.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GroupTreeContents.Commands.Delete;

public class DeleteGroupTreeContentCommand : IRequest<DeletedGroupTreeContentResponse>
{
    public int Id { get; set; }
    

    public class DeleteGroupTreeContentCommandHandler : IRequestHandler<DeleteGroupTreeContentCommand, DeletedGroupTreeContentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGroupTreeContentRepository _groupTreeContentRepository;
        private readonly GroupTreeContentBusinessRules _groupTreeContentBusinessRules;

        public DeleteGroupTreeContentCommandHandler(IMapper mapper, IGroupTreeContentRepository groupTreeContentRepository,
                                         GroupTreeContentBusinessRules groupTreeContentBusinessRules)
        {
            _mapper = mapper;
            _groupTreeContentRepository = groupTreeContentRepository;
            _groupTreeContentBusinessRules = groupTreeContentBusinessRules;
        }

        public async Task<DeletedGroupTreeContentResponse> Handle(DeleteGroupTreeContentCommand request, CancellationToken cancellationToken)
        {
            GroupTreeContent groupTreeContent = _groupTreeContentRepository.Get(b => b.Id == request.Id);

            _groupTreeContentRepository.Delete(groupTreeContent);

            DeletedGroupTreeContentResponse response = _mapper.Map<DeletedGroupTreeContentResponse>(groupTreeContent);
            return response;
        }
    }
}