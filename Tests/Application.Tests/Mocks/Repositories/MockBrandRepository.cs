using Application.Services.Repositories;
using Domain.Entities;
using Freezone.Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
//using static FluentValidation.Validators.PredicateValidator<T, TProperty>;

namespace Application.Tests.Mocks.Repositories
{
    public static class MockBrandRepository
    {
        public static Mock<IBrandRepository> GetBrandRepositoryMock()
        {
            var brands = new List<Brand>
            {
                new(){ Id=1, Name="BMW",Status=1,CreatedDate=DateTime.Now,UpdatedDate=DateTime.Now },
                new(){ Id=2, Name="Fiat",Status=1,CreatedDate=DateTime.Now,UpdatedDate=DateTime.Now },
            };
            var mockRepository = new Mock<IBrandRepository>();


            #region GetList method mock
            Paginate<Brand> brandList = new()
            {
                Items = brands
            };
            mockRepository.Setup(s => s.GetList(
                It.IsAny<Expression<Func<Brand, bool>>>(), 
                It.IsAny<Func<IQueryable<Brand>, IOrderedQueryable<Brand>>>(),
                It.IsAny<Func<IQueryable<Brand>, IIncludableQueryable<Brand, object>>>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<bool>()
                ))
                .Returns(brandList);

            //.Returns((Expression<Func<Brand, bool>> predicate, Func<IQueryable<Brand>, 
            //        IOrderedQueryable<Brand>> orderBy, Func<IQueryable<Brand>, 
            //        IIncludableQueryable<Brand, object>> include, int index, int size, bool enableTracking) =>
            //{
            //    IList<Brand> brandList;
            //    brandList = brands.Where(predicate.Compile()).ToList();
            //    Paginate<Brand> list = new()
            //    {
            //        Items = brandList
            //    };
            //    return list;
            //});
            #endregion
            #region Add Method Mock
            var brandToAdd = new Domain.Entities.Brand()
            {
                Name="Mercedes",
                Id=3,
                CreatedDate=DateTime.Now,
                Status=1,
                UpdatedDate=DateTime.Now,
            };
            // It.IsAny<Brand>() => Gelecek parametre herhangi bir Brand nesnesi olabilir
            mockRepository
                .Setup(s => s.Add(It.IsAny<Brand>()))
                .Returns(brandToAdd);
            #endregion

            return mockRepository;
        }
    }
}
