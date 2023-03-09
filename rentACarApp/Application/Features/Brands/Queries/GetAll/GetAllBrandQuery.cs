using Application.Features.Brands.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetAll
{
    public class GetAllBrandQuery : IRequest<IEnumerable<GetAllBrandDto>>
    {
        public class GetAllBrandQueryHandler : IRequestHandler<GetAllBrandQuery, IEnumerable<GetAllBrandDto>>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;

            public GetAllBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<GetAllBrandDto>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
            {
                // Sayfalama olmadan tüm verileri listele.
                //IPaginate<Brand> brands = await _brandRepository.GetListAsync(index: request.PageRequest.Page,
                //size: request.PageRequest.PageSize);
                IEnumerable<Brand> brands = await _brandRepository.GetAllAsync();
                IEnumerable<GetAllBrandDto> response = _mapper.Map<IEnumerable<GetAllBrandDto>>(brands);

                return response.ToList();
            }

           
        }
    }
}
