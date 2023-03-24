using Application.Features.TitleDefinitons.Constants;
using Application.Features.TitleDefinitons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TitleDefinitons.Commands.Delete;

public class DeleteTitleDefinitonCommand : IRequest<DeletedTitleDefinitonResponse>
{
    public int Id { get; set; }
    

    public class DeleteTitleDefinitonCommandHandler : IRequestHandler<DeleteTitleDefinitonCommand, DeletedTitleDefinitonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleDefinitonRepository _titleDefinitonRepository;
        private readonly TitleDefinitonBusinessRules _titleDefinitonBusinessRules;

        public DeleteTitleDefinitonCommandHandler(IMapper mapper, ITitleDefinitonRepository titleDefinitonRepository,
                                         TitleDefinitonBusinessRules titleDefinitonBusinessRules)
        {
            _mapper = mapper;
            _titleDefinitonRepository = titleDefinitonRepository;
            _titleDefinitonBusinessRules = titleDefinitonBusinessRules;
        }

        public async Task<DeletedTitleDefinitonResponse> Handle(DeleteTitleDefinitonCommand request, CancellationToken cancellationToken)
        {
            TitleDefinition titleDefiniton = _titleDefinitonRepository.Get(b => b.Id == request.Id);

            _titleDefinitonRepository.Delete(titleDefiniton);

            DeletedTitleDefinitonResponse response = _mapper.Map<DeletedTitleDefinitonResponse>(titleDefiniton);
            return response;
        }
    }
}