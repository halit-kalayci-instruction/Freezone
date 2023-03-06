using Application.Features.Transmissions.Constants;
using Application.Features.Transmissions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Transmissions.Commands.Delete;

public class DeleteTransmissionCommand : IRequest<DeletedTransmissionResponse>, ICacheRemoverRequest
{
    public int Id { get; set; }
    

    public bool BypassCache { get; }
    public string CacheKey => "GetListTransmission";

    public class DeleteTransmissionCommandHandler : IRequestHandler<DeleteTransmissionCommand, DeletedTransmissionResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly TransmissionBusinessRules _transmissionBusinessRules;

        public DeleteTransmissionCommandHandler(IMapper mapper, ITransmissionRepository transmissionRepository,
                                         TransmissionBusinessRules transmissionBusinessRules)
        {
            _mapper = mapper;
            _transmissionRepository = transmissionRepository;
            _transmissionBusinessRules = transmissionBusinessRules;
        }

        public async Task<DeletedTransmissionResponse> Handle(DeleteTransmissionCommand request, CancellationToken cancellationToken)
        {
            Transmission transmission = _transmissionRepository.Get(b => b.Id == request.Id);

            _transmissionRepository.Delete(transmission);

            DeletedTransmissionResponse response = _mapper.Map<DeletedTransmissionResponse>(transmission);
            return response;
        }
    }
}