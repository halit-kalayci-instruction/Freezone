using Application.Features.CarImages.Constants;
using Application.Features.CarImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Freezone.Core.Application.Pipelines.Authorization;
using Freezone.Core.Application.Pipelines.Caching;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.CarImages.Commands.Create;

public class CreateCarImageCommand : IRequest<CreatedCarImageResponse>, ISecuredOperation, ICacheRemoverRequest
{
    public int CarId { get; set; }
    public IFormFile File { get; set; }

    public string[] Roles => new[] { CarImagesRoles.Create };

    public bool BypassCache { get; }
    public string CacheKey => "GetListCarImage";

    public class CreateCarImageCommandHandler : IRequestHandler<CreateCarImageCommand, CreatedCarImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICarImageRepository _carImageRepository;
        private readonly CarImageBusinessRules _carImageBusinessRules;

        public CreateCarImageCommandHandler(IMapper mapper, ICarImageRepository carImageRepository,
                                         CarImageBusinessRules carImageBusinessRules)
        {
            _mapper = mapper;
            _carImageRepository = carImageRepository;
            _carImageBusinessRules = carImageBusinessRules;
        }

        public async Task<CreatedCarImageResponse> Handle(CreateCarImageCommand request, CancellationToken cancellationToken)
        {
            CarImage mappedCarImage = _mapper.Map<CarImage>(request);
            // File'ý upload et, carImage'in path deðerine ata.
            if(request.File != null)
            {
                string fileExtension = System.IO.Path.GetExtension(request.File.FileName);
                string randomName = $"{Guid.NewGuid()}{fileExtension}";
                // C:\Users\klyyc\Desktop\Projects\NET\Freezone\rentACarApp\WebAPI\ 
                // wwwroot\carimages
                // 12481-dasjd12-14128.png
                // C:\Users\klyyc\Desktop\Projects\NET\Freezone\rentACarApp\WebAPI\wwwroot\carimages\12481-dasjd12-14128.png
                // www.api.esbas.com/carimages/12481-dasjd12-14128.png
                // carimages/12481-dasjd12-14128.png
                var path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\carimages", randomName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await request.File.CopyToAsync(stream);
                    mappedCarImage.Path = @"carimages/" + randomName;
                }
            }
            _carImageRepository.Add(mappedCarImage);

            CreatedCarImageResponse response = _mapper.Map<CreatedCarImageResponse>(mappedCarImage);
            return response;
        }
    }
}