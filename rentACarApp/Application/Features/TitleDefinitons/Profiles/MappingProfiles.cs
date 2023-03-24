using Application.Features.TitleDefinitons.Commands.Create;
using Application.Features.TitleDefinitons.Commands.Delete;
using Application.Features.TitleDefinitons.Commands.Update;
using Application.Features.TitleDefinitons.Queries.GetById;
using Application.Features.TitleDefinitons.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Persistence.Paging;

namespace Application.Features.TitleDefinitons.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<TitleDefinition, CreateTitleDefinitonCommand>().ReverseMap();
        CreateMap<TitleDefinition, CreatedTitleDefinitonResponse>().ReverseMap();
        CreateMap<TitleDefinition, UpdateTitleDefinitonCommand>().ReverseMap();
        CreateMap<TitleDefinition, UpdatedTitleDefinitonResponse>().ReverseMap();
        CreateMap<TitleDefinition, DeleteTitleDefinitonCommand>().ReverseMap();
        CreateMap<TitleDefinition, DeletedTitleDefinitonResponse>().ReverseMap();
        CreateMap<TitleDefinition, GetByIdTitleDefinitonResponse>().ReverseMap();
        CreateMap<TitleDefinition, GetListTitleDefinitonDto>().ReverseMap();
        CreateMap<IPaginate<TitleDefinition>, GetListResponse<GetListTitleDefinitonDto>>().ReverseMap();
    }
}