using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Profiles;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using Application.Tests.Mocks.Repositories;
using AutoMapper;
using FluentValidation;
using Freezone.Core.CrossCuttingConcerns.Exceptions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.Brands.Commands.Create.CreateBrandCommand;

namespace Application.Tests.FeatureTests.Brands
{
    public class BrandsTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IBrandRepository> _mockBrandRepository;
        private readonly BrandBusinessRules _brandBusinessRules;
        public BrandsTests()
        {
            // İlgili test bağımlılıkların yüklenmesi
            _mockBrandRepository = MockBrandRepository.GetBrandRepositoryMock();
            _brandBusinessRules = new BrandBusinessRules(_mockBrandRepository.Object);
            // Configuration
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfiles>();
            });
            _mapper = mapperConfig.CreateMapper();
        }
        [Fact]
        public async Task AddBrandWhenNotDuplicated()
        {
            string carNameToAdd = "Audi";
            CreateBrandCommand command = new()
            {
                Name = carNameToAdd
            };
            CreateBrandCommandHandler handler = new(_mapper,_mockBrandRepository.Object,_brandBusinessRules);

            var result = await handler.Handle(command, CancellationToken.None);
            Assert.Equal(carNameToAdd, result.Name);
        }

        [Fact]
        public async Task ShouldNotAddWhenDuplicated()
        {
            string carNameToAdd = "BMW";
            CreateBrandCommand command = new()
            {
                Name = carNameToAdd
            };
            CreateBrandCommandHandler handler = new(_mapper, _mockBrandRepository.Object, _brandBusinessRules);

            await Assert.ThrowsAsync<BusinessException>(async () => await handler.Handle(command, CancellationToken.None));
        }

    }
}
