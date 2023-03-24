using Application.Features.UserTitleDefinitons.Constants;
using Application.Features.UserTitleDefinitons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.UserTitleDefinitons.Commands.Create;

public class CreateUserTitleDefinitonCommand : IRequest<CreatedUserTitleDefinitonResponse>, ISecuredOperation
{
    public int UserId { get; set; }
    public int HrTitleDefinitonId { get; set; }

    public string[] Roles => new[] { UserTitleDefinitonsRoles.Create };

    public class CreateUserTitleDefinitonCommandHandler : IRequestHandler<CreateUserTitleDefinitonCommand, CreatedUserTitleDefinitonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserTitleDefinitonRepository _userTitleDefinitonRepository;
        private readonly UserTitleDefinitonBusinessRules _userTitleDefinitonBusinessRules;

        public CreateUserTitleDefinitonCommandHandler(IMapper mapper, IUserTitleDefinitonRepository userTitleDefinitonRepository,
                                         UserTitleDefinitonBusinessRules userTitleDefinitonBusinessRules)
        {
            _mapper = mapper;
            _userTitleDefinitonRepository = userTitleDefinitonRepository;
            _userTitleDefinitonBusinessRules = userTitleDefinitonBusinessRules;
        }

        public async Task<CreatedUserTitleDefinitonResponse> Handle(CreateUserTitleDefinitonCommand request, CancellationToken cancellationToken)
        {
            UserTitleDefiniton mappedUserTitleDefiniton = _mapper.Map<UserTitleDefiniton>(request);

            _userTitleDefinitonRepository.Add(mappedUserTitleDefiniton);

            CreatedUserTitleDefinitonResponse response = _mapper.Map<CreatedUserTitleDefinitonResponse>(mappedUserTitleDefiniton);
            return response;
        }
    }
}