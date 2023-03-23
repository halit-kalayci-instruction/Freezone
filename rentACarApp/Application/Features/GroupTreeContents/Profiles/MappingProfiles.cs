using Application.Features.GroupTreeContents.Commands.Create;
using Application.Features.GroupTreeContents.Commands.Delete;
using Application.Features.GroupTreeContents.Commands.Update;
using Application.Features.GroupTreeContents.Queries.GetById;
using Application.Features.GroupTreeContents.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Persistence.Paging;

namespace Application.Features.GroupTreeContents.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<GroupTreeContent, CreateGroupTreeContentCommand>().ReverseMap();
        CreateMap<GroupTreeContent, CreatedGroupTreeContentResponse>().ReverseMap();
        CreateMap<GroupTreeContent, UpdateGroupTreeContentCommand>().ReverseMap();
        CreateMap<GroupTreeContent, UpdatedGroupTreeContentResponse>().ReverseMap();
        CreateMap<GroupTreeContent, DeleteGroupTreeContentCommand>().ReverseMap();
        CreateMap<GroupTreeContent, DeletedGroupTreeContentResponse>().ReverseMap();
        CreateMap<GroupTreeContent, GetByIdGroupTreeContentResponse>().ReverseMap();
        CreateMap<GroupTreeContent, GetListGroupTreeContentDto>().ReverseMap();
        CreateMap<IPaginate<GroupTreeContent>, GetListResponse<GetListGroupTreeContentDto>>().ReverseMap();
    }
}