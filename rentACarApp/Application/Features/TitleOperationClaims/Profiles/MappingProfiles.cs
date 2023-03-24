using Application.Features.TitleOperationClaims.Commands.Create;
using Application.Features.TitleOperationClaims.Commands.Delete;
using Application.Features.TitleOperationClaims.Commands.Update;
using Application.Features.TitleOperationClaims.Queries.GetById;
using Application.Features.TitleOperationClaims.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Persistence.Paging;

namespace Application.Features.TitleOperationClaims.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<TitleOperationClaim, CreateTitleOperationClaimCommand>().ReverseMap();
        CreateMap<TitleOperationClaim, CreatedTitleOperationClaimResponse>().ReverseMap();
        CreateMap<TitleOperationClaim, UpdateTitleOperationClaimCommand>().ReverseMap();
        CreateMap<TitleOperationClaim, UpdatedTitleOperationClaimResponse>().ReverseMap();
        CreateMap<TitleOperationClaim, DeleteTitleOperationClaimCommand>().ReverseMap();
        CreateMap<TitleOperationClaim, DeletedTitleOperationClaimResponse>().ReverseMap();
        CreateMap<TitleOperationClaim, GetByIdTitleOperationClaimResponse>().ReverseMap();
        CreateMap<TitleOperationClaim, GetListTitleOperationClaimDto>().ReverseMap();
        CreateMap<IPaginate<TitleOperationClaim>, GetListResponse<GetListTitleOperationClaimDto>>().ReverseMap();
    }
}