using Application.Features.UserTitleDefinitons.Constants;
using Application.Features.UserTitleDefinitons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.UserTitleDefinitons.Commands.Update;

public class UpdateUserTitleDefinitonCommand : IRequest<UpdatedUserTitleDefinitonResponse>, ISecuredOperation
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int HrTitleDefinitonId { get; set; }
    
    
        public string[] Roles => new string[] { UserTitleDefinitonsRoles.Update };

    public class UpdateUserTitleDefinitonCommandHandler : IRequestHandler<UpdateUserTitleDefinitonCommand, UpdatedUserTitleDefinitonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserTitleDefinitonRepository _userTitleDefinitonRepository;
        private readonly UserTitleDefinitonBusinessRules _userTitleDefinitonBusinessRules;

        public UpdateUserTitleDefinitonCommandHandler(IMapper mapper, IUserTitleDefinitonRepository userTitleDefinitonRepository,
                                         UserTitleDefinitonBusinessRules userTitleDefinitonBusinessRules)
        {
            _mapper = mapper;
            _userTitleDefinitonRepository = userTitleDefinitonRepository;
            _userTitleDefinitonBusinessRules = userTitleDefinitonBusinessRules;
        }

        public async Task<UpdatedUserTitleDefinitonResponse> Handle(UpdateUserTitleDefinitonCommand request, CancellationToken cancellationToken)
        {
            UserTitleDefiniton userTitleDefiniton = _userTitleDefinitonRepository.Get(b => b.Id == request.Id);
            UserTitleDefiniton mappedUserTitleDefiniton = _mapper.Map(request, userTitleDefiniton);

            _userTitleDefinitonRepository.Update(mappedUserTitleDefiniton);

            UpdatedUserTitleDefinitonResponse response = _mapper.Map<UpdatedUserTitleDefinitonResponse>(userTitleDefiniton);
            return response;
        }
    }
}