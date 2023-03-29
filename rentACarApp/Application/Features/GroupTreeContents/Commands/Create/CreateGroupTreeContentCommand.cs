using Application.Features.GroupTreeContentOperationClaims.Commands.Create;
using Application.Features.GroupTreeContents.Constants;
using Application.Features.GroupTreeContents.Rules;
using Application.Services.GroupTreeContentOperationClaimService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Pipelines.Logging;
using Freezone.Core.Application.Pipelines.Transaction;
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
    public List<int> OperationClaimIds { get; set; }


    public class CreateGroupTreeContentCommandHandler : IRequestHandler<CreateGroupTreeContentCommand, CreatedGroupTreeContentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGroupTreeContentRepository _groupTreeContentRepository;
        private readonly GroupTreeContentBusinessRules _groupTreeContentBusinessRules;
        private readonly IGroupTreeContentOperationClaimService _groupTreeContentOperationClaimService;
        public CreateGroupTreeContentCommandHandler(IMapper mapper, IGroupTreeContentRepository groupTreeContentRepository,
                                         GroupTreeContentBusinessRules groupTreeContentBusinessRules, IGroupTreeContentOperationClaimService groupTreeContentOperationClaimService)
        {
            _mapper = mapper;
            _groupTreeContentRepository = groupTreeContentRepository;
            _groupTreeContentBusinessRules = groupTreeContentBusinessRules;
            _groupTreeContentOperationClaimService = groupTreeContentOperationClaimService;
        }

        public async Task<CreatedGroupTreeContentResponse> Handle(CreateGroupTreeContentCommand request, CancellationToken cancellationToken)
        {
            GroupTreeContent mappedGroupTreeContent = _mapper.Map<GroupTreeContent>(request);

            _groupTreeContentRepository.Add(mappedGroupTreeContent);

            var operationClaims = request.OperationClaimIds.Select(i => new CreateGroupTreeContentOperationClaimCommand()
            {
                OperationClaimId = i,
                GroupTreeContentId = mappedGroupTreeContent.Id
            }).ToList();
            throw new Exception();
            await _groupTreeContentOperationClaimService.AddRange(operationClaims);
            CreatedGroupTreeContentResponse response = _mapper.Map<CreatedGroupTreeContentResponse>(mappedGroupTreeContent);
            return response;
        }
    }
}