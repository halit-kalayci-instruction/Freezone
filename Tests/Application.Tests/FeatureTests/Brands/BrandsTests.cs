using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Profiles;
using Application.Features.Brands.Queries.GetList;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using Application.Tests.Mocks.Repositories.Brands;
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
using static Application.Features.Brands.Queries.GetList.GetListBrandQuery;

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

        [Fact]
        public async Task GetAllBrands()
        {
            GetListBrandQuery query = new() { PageRequest= new() { Page=0, PageSize=10} };
            GetListBrandQueryHandler handler = new(_mockBrandRepository.Object, _mapper);

            var result = await handler.Handle(query, CancellationToken.None);
            //bool testResult = (result.Items.Count == 2 && result.Index == 0 && result.Size == 10);
            Assert.Equal(2, result.Items.Count);
        }
    }
}
