using Application.Features.Transmissions.Commands.Create;
using Application.Features.Transmissions.Commands.Delete;
using Application.Features.Transmissions.Commands.Update;
using Application.Features.Transmissions.Queries.GetById;
using Application.Features.Transmissions.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Persistence.Paging;

namespace Application.Features.Transmissions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Transmission, CreateTransmissionCommand>().ReverseMap();
        CreateMap<Transmission, CreatedTransmissionResponse>().ReverseMap();
        CreateMap<Transmission, UpdateTransmissionCommand>().ReverseMap();
        CreateMap<Transmission, UpdatedTransmissionResponse>().ReverseMap();
        CreateMap<Transmission, DeleteTransmissionCommand>().ReverseMap();
        CreateMap<Transmission, DeletedTransmissionResponse>().ReverseMap();
        CreateMap<Transmission, GetByIdTransmissionResponse>().ReverseMap();
        CreateMap<Transmission, GetListTransmissionDto>().ReverseMap();
        CreateMap<IPaginate<Transmission>, GetListResponse<GetListTransmissionDto>>().ReverseMap();
    }
}