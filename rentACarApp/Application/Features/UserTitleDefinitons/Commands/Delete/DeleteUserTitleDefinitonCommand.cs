using Application.Features.UserTitleDefinitons.Constants;
using Application.Features.UserTitleDefinitons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.UserTitleDefinitons.Commands.Delete;

public class DeleteUserTitleDefinitonCommand : IRequest<DeletedUserTitleDefinitonResponse>, ISecuredOperation
{
    public int Id { get; set; }
    
    
        public string[] Roles => new string[] { UserTitleDefinitonsRoles.Delete };

    public class DeleteUserTitleDefinitonCommandHandler : IRequestHandler<DeleteUserTitleDefinitonCommand, DeletedUserTitleDefinitonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserTitleDefinitonRepository _userTitleDefinitonRepository;
        private readonly UserTitleDefinitonBusinessRules _userTitleDefinitonBusinessRules;

        public DeleteUserTitleDefinitonCommandHandler(IMapper mapper, IUserTitleDefinitonRepository userTitleDefinitonRepository,
                                         UserTitleDefinitonBusinessRules userTitleDefinitonBusinessRules)
        {
            _mapper = mapper;
            _userTitleDefinitonRepository = userTitleDefinitonRepository;
            _userTitleDefinitonBusinessRules = userTitleDefinitonBusinessRules;
        }

        public async Task<DeletedUserTitleDefinitonResponse> Handle(DeleteUserTitleDefinitonCommand request, CancellationToken cancellationToken)
        {
            UserTitleDefiniton userTitleDefiniton = _userTitleDefinitonRepository.Get(b => b.Id == request.Id);

            _userTitleDefinitonRepository.Delete(userTitleDefiniton);

            DeletedUserTitleDefinitonResponse response = _mapper.Map<DeletedUserTitleDefinitonResponse>(userTitleDefiniton);
            return response;
        }
    }
}