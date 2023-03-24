using Application.Features.UserTitleDefinitons.Commands.Create;
using Application.Features.UserTitleDefinitons.Commands.Delete;
using Application.Features.UserTitleDefinitons.Commands.Update;
using Application.Features.UserTitleDefinitons.Queries.GetById;
using Application.Features.UserTitleDefinitons.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Persistence.Paging;

namespace Application.Features.UserTitleDefinitons.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserTitleDefiniton, CreateUserTitleDefinitonCommand>().ReverseMap();
        CreateMap<UserTitleDefiniton, CreatedUserTitleDefinitonResponse>().ReverseMap();
        CreateMap<UserTitleDefiniton, UpdateUserTitleDefinitonCommand>().ReverseMap();
        CreateMap<UserTitleDefiniton, UpdatedUserTitleDefinitonResponse>().ReverseMap();
        CreateMap<UserTitleDefiniton, DeleteUserTitleDefinitonCommand>().ReverseMap();
        CreateMap<UserTitleDefiniton, DeletedUserTitleDefinitonResponse>().ReverseMap();
        CreateMap<UserTitleDefiniton, GetByIdUserTitleDefinitonResponse>().ReverseMap();
        CreateMap<UserTitleDefiniton, GetListUserTitleDefinitonDto>().ReverseMap();
        CreateMap<IPaginate<UserTitleDefiniton>, GetListResponse<GetListUserTitleDefinitonDto>>().ReverseMap();
    }
}