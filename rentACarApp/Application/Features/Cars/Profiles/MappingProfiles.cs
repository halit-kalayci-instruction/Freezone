﻿using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Commands.Delete;
using Application.Features.Cars.Commands.Update;
using Application.Features.Cars.Queries.GetById;
using Application.Features.Cars.Queries.GetList;
using Application.Features.Cars.Queries.GetListByDynamic;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Car, DeletedCarResponse>().ReverseMap();
            CreateMap<Car, CreatedCarResponse>().ReverseMap();
            CreateMap<Car, CreateCarCommand>().ReverseMap();
            CreateMap<Car, UpdatedCarResponse>().ReverseMap();
            CreateMap<Car, UpdateCarCommand>().ReverseMap();
            CreateMap<Car, GetByIdCarQuery>().ReverseMap();
            CreateMap<Car, GetByIdCarResponse>().ForMember(c=>c.BrandId, opt=>opt.MapFrom(c=>c.Model.BrandId)).ReverseMap();


            CreateMap<Car, GetListCarDto>().ForMember(c=>c.ModelName, opt=>opt.MapFrom(c=>c.Model.Name))
                                           .ForMember(c => c.BrandName, opt => opt.MapFrom(c => c.Model.Brand.Name))
                                           .ForMember(c=>c.ModelId, opt=>opt.MapFrom(c=>c.Model.Id))
                                           .ReverseMap();


            CreateMap<IPaginate<Car>, GetListResponse<GetListCarDto>>().ReverseMap();

            CreateMap<Car, GetListCarByDynamicDto>().ForMember(c => c.ModelName, opt => opt.MapFrom(c => c.Model.Name))
                                            .ForMember(c => c.BrandId, opt => opt.MapFrom(c => c.Model.BrandId))
                                            .ForMember(c => c.ModelId, opt => opt.MapFrom(c => c.Model.Id))
                                           .ForMember(c => c.BrandName, opt => opt.MapFrom(c => c.Model.Brand.Name)).ReverseMap();


            CreateMap<IPaginate<Car>, GetListResponse<GetListCarByDynamicDto>>().ReverseMap();
        }
    }
}
