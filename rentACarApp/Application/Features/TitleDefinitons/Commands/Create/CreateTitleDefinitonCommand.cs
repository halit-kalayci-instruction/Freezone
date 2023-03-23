using Application.Features.TitleDefinitons.Constants;
using Application.Features.TitleDefinitons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TitleDefinitons.Commands.Create;

public class CreateTitleDefinitonCommand : IRequest<CreatedTitleDefinitonResponse>
{
    public string Name { get; set; }

    public class CreateTitleDefinitonCommandHandler : IRequestHandler<CreateTitleDefinitonCommand, CreatedTitleDefinitonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleDefinitonRepository _titleDefinitonRepository;
        private readonly TitleDefinitonBusinessRules _titleDefinitonBusinessRules;

        public CreateTitleDefinitonCommandHandler(IMapper mapper, ITitleDefinitonRepository titleDefinitonRepository,
                                         TitleDefinitonBusinessRules titleDefinitonBusinessRules)
        {
            _mapper = mapper;
            _titleDefinitonRepository = titleDefinitonRepository;
            _titleDefinitonBusinessRules = titleDefinitonBusinessRules;
        }

        public async Task<CreatedTitleDefinitonResponse> Handle(CreateTitleDefinitonCommand request, CancellationToken cancellationToken)
        {
            TitleDefiniton mappedTitleDefiniton = _mapper.Map<TitleDefiniton>(request);

            _titleDefinitonRepository.Add(mappedTitleDefiniton);

            CreatedTitleDefinitonResponse response = _mapper.Map<CreatedTitleDefinitonResponse>(mappedTitleDefiniton);
            return response;
        }
    }
}