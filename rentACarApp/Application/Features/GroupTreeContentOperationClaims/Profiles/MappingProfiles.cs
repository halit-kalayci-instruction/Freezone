using Application.Features.GroupTreeContentOperationClaims.Commands.Create;
using Application.Features.GroupTreeContentOperationClaims.Commands.Delete;
using Application.Features.GroupTreeContentOperationClaims.Commands.Update;
using Application.Features.GroupTreeContentOperationClaims.Queries.GetById;
using Application.Features.GroupTreeContentOperationClaims.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Persistence.Paging;

namespace Application.Features.GroupTreeContentOperationClaims.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<GroupTreeContentOperationClaim, CreateGroupTreeContentOperationClaimCommand>().ReverseMap();
        CreateMap<GroupTreeContentOperationClaim, CreatedGroupTreeContentOperationClaimResponse>().ReverseMap();
        CreateMap<GroupTreeContentOperationClaim, UpdateGroupTreeContentOperationClaimCommand>().ReverseMap();
        CreateMap<GroupTreeContentOperationClaim, UpdatedGroupTreeContentOperationClaimResponse>().ReverseMap();
        CreateMap<GroupTreeContentOperationClaim, DeleteGroupTreeContentOperationClaimCommand>().ReverseMap();
        CreateMap<GroupTreeContentOperationClaim, DeletedGroupTreeContentOperationClaimResponse>().ReverseMap();
        CreateMap<GroupTreeContentOperationClaim, GetByIdGroupTreeContentOperationClaimResponse>().ReverseMap();
        CreateMap<GroupTreeContentOperationClaim, GetListGroupTreeContentOperationClaimDto>().ReverseMap();
        CreateMap<IPaginate<GroupTreeContentOperationClaim>, GetListResponse<GetListGroupTreeContentOperationClaimDto>>().ReverseMap();
    }
}