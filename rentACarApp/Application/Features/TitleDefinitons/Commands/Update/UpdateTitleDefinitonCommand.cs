using Application.Features.TitleDefinitons.Constants;
using Application.Features.TitleDefinitons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TitleDefinitons.Commands.Update;

public class UpdateTitleDefinitonCommand : IRequest<UpdatedTitleDefinitonResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }
    

    public class UpdateTitleDefinitonCommandHandler : IRequestHandler<UpdateTitleDefinitonCommand, UpdatedTitleDefinitonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleDefinitonRepository _titleDefinitonRepository;
        private readonly TitleDefinitonBusinessRules _titleDefinitonBusinessRules;

        public UpdateTitleDefinitonCommandHandler(IMapper mapper, ITitleDefinitonRepository titleDefinitonRepository,
                                         TitleDefinitonBusinessRules titleDefinitonBusinessRules)
        {
            _mapper = mapper;
            _titleDefinitonRepository = titleDefinitonRepository;
            _titleDefinitonBusinessRules = titleDefinitonBusinessRules;
        }

        public async Task<UpdatedTitleDefinitonResponse> Handle(UpdateTitleDefinitonCommand request, CancellationToken cancellationToken)
        {
            TitleDefiniton titleDefiniton = _titleDefinitonRepository.Get(b => b.Id == request.Id);
            TitleDefiniton mappedTitleDefiniton = _mapper.Map(request, titleDefiniton);

            _titleDefinitonRepository.Update(mappedTitleDefiniton);

            UpdatedTitleDefinitonResponse response = _mapper.Map<UpdatedTitleDefinitonResponse>(titleDefiniton);
            return response;
        }
    }
}