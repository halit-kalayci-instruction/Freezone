using Application.Features.Transmissions.Constants;
using Application.Features.Transmissions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Transmissions.Commands.Update;

public class UpdateTransmissionCommand : IRequest<UpdatedTransmissionResponse>, ICacheRemoverRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    

    public bool BypassCache { get; }
    public string CacheKey => "GetListTransmission";

    public class UpdateTransmissionCommandHandler : IRequestHandler<UpdateTransmissionCommand, UpdatedTransmissionResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly TransmissionBusinessRules _transmissionBusinessRules;

        public UpdateTransmissionCommandHandler(IMapper mapper, ITransmissionRepository transmissionRepository,
                                         TransmissionBusinessRules transmissionBusinessRules)
        {
            _mapper = mapper;
            _transmissionRepository = transmissionRepository;
            _transmissionBusinessRules = transmissionBusinessRules;
        }

        public async Task<UpdatedTransmissionResponse> Handle(UpdateTransmissionCommand request, CancellationToken cancellationToken)
        {
            Transmission transmission = _transmissionRepository.Get(b => b.Id == request.Id);
            Transmission mappedTransmission = _mapper.Map(request, transmission);

            _transmissionRepository.Update(mappedTransmission);

            UpdatedTransmissionResponse response = _mapper.Map<UpdatedTransmissionResponse>(transmission);
            return response;
        }
    }
}