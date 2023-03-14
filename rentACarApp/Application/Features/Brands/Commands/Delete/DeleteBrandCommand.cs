using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Delete
{
    public class DeleteBrandCommand : IRequest<DeletedBrandResponse>
    {
        public int Id { get; set; }

        public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeletedBrandResponse>
        {
            public IMapper _mapper;
            public IBrandRepository _brandRepository;
            public BrandBusinessRules _brandBusinessRules;

            public DeleteBrandCommandHandler(IMapper mapper, IBrandRepository brandRepository, BrandBusinessRules brandBusinessRules)
            {
                _mapper = mapper;
                _brandRepository = brandRepository;
                _brandBusinessRules = brandBusinessRules;
            }
            // Brand'e ait araç olma durumu?
            // verilen id ile brand var mı?
            public async Task<DeletedBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {
                Brand? brandToDelete = await _brandRepository.GetAsync(i => i.Id == request.Id);
                //
                // Business Rules
                //
                await _brandRepository.DeleteAsync(brandToDelete);
                DeletedBrandResponse response = _mapper.Map<DeletedBrandResponse>(brandToDelete);
                return response;
            }
        }
    }
}
