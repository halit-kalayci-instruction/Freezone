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
        CreateMap<TitleDefiniton, CreateTitleDefinitonCommand>().ReverseMap();
        CreateMap<TitleDefiniton, CreatedTitleDefinitonResponse>().ReverseMap();
        CreateMap<TitleDefiniton, UpdateTitleDefinitonCommand>().ReverseMap();
        CreateMap<TitleDefiniton, UpdatedTitleDefinitonResponse>().ReverseMap();
        CreateMap<TitleDefiniton, DeleteTitleDefinitonCommand>().ReverseMap();
        CreateMap<TitleDefiniton, DeletedTitleDefinitonResponse>().ReverseMap();
        CreateMap<TitleDefiniton, GetByIdTitleDefinitonResponse>().ReverseMap();
        CreateMap<TitleDefiniton, GetListTitleDefinitonDto>().ReverseMap();
        CreateMap<IPaginate<TitleDefiniton>, GetListResponse<GetListTitleDefinitonDto>>().ReverseMap();
    }
}