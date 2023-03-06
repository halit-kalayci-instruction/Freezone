using Application.Features.Transmissions.Constants;
using Application.Features.Transmissions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Transmissions.Commands.Create;

public class CreateTransmissionCommand : IRequest<CreatedTransmissionResponse>, ICacheRemoverRequest
{
    public string Name { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => "GetListTransmission";

    public class CreateTransmissionCommandHandler : IRequestHandler<CreateTransmissionCommand, CreatedTransmissionResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly TransmissionBusinessRules _transmissionBusinessRules;

        public CreateTransmissionCommandHandler(IMapper mapper, ITransmissionRepository transmissionRepository,
                                         TransmissionBusinessRules transmissionBusinessRules)
        {
            _mapper = mapper;
            _transmissionRepository = transmissionRepository;
            _transmissionBusinessRules = transmissionBusinessRules;
        }

        public async Task<CreatedTransmissionResponse> Handle(CreateTransmissionCommand request, CancellationToken cancellationToken)
        {
            Transmission mappedTransmission = _mapper.Map<Transmission>(request);

            _transmissionRepository.Add(mappedTransmission);

            CreatedTransmissionResponse response = _mapper.Map<CreatedTransmissionResponse>(mappedTransmission);
            return response;
        }
    }
}