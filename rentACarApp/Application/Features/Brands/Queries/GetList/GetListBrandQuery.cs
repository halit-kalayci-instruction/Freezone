﻿using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Pipelines.Caching;
using Freezone.Core.Application.Requests;
using Freezone.Core.Persistence.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freezone.Core.Application.Pipelines.Authorization;

namespace Application.Features.Brands.Queries.GetList
{
    public class GetListBrandQuery:IRequest<GetListResponse<GetListBrandDto>>
        //,ISecuredOperation
        // ISecuredOperation olmayan/korunmayan operasyonları anonim/login yapmamış kullanıcılarda kullanabilecek.
    {
        public PageRequest PageRequest { get; set; }

        public bool BypassCache { get; }

        public string CacheKey => "GetListBrand";

        public TimeSpan? SlidingExpiration { get; }
        // public string[] Roles => Array.Empty<string>(); // Sadece login olması yeterli
        public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery, GetListResponse<GetListBrandDto>>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;

            public GetListBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListBrandDto>> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Brand> brands = await _brandRepository.GetListAsync(index: request.PageRequest.Page,
                                                                              size: request.PageRequest.PageSize);
                GetListResponse<GetListBrandDto> response = _mapper.Map<GetListResponse<GetListBrandDto>>(brands);
                Thread.Sleep(3000);
                return response;
            }
        }

    }
}
