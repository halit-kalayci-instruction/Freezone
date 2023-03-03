using Application.Features.CarImages.Commands.Create;
using Application.Features.CarImages.Commands.Delete;
using Application.Features.CarImages.Commands.Update;
using Application.Features.CarImages.Queries.GetById;
using Application.Features.CarImages.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Persistence.Paging;

namespace Application.Features.CarImages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CarImage, CreateCarImageCommand>().ReverseMap();
        CreateMap<CarImage, CreatedCarImageResponse>().ReverseMap();
        CreateMap<CarImage, UpdateCarImageCommand>().ReverseMap();
        CreateMap<CarImage, UpdatedCarImageResponse>().ReverseMap();
        CreateMap<CarImage, DeleteCarImageCommand>().ReverseMap();
        CreateMap<CarImage, DeletedCarImageResponse>().ReverseMap();
        CreateMap<CarImage, GetByIdCarImageResponse>().ReverseMap();
        CreateMap<CarImage, GetListCarImageDto>().ReverseMap();
        CreateMap<IPaginate<CarImage>, GetListResponse<GetListCarImageDto>>().ReverseMap();
    }
}