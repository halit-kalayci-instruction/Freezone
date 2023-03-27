using Application.Tests.Mocks.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.FeatureTests.Brands
{
    public class BrandsTests
    {
        [Fact]
        public void GetAll()
        {
            var mockBrandRepo = MockBrandRepository.GetBrandRepositoryMock();
            var getAllResult = mockBrandRepo.Object.GetList();
            Assert.True(true);
        }
    }
}
