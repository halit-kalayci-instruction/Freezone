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
using System.Threading;
using System.Threading.Tasks;
//using static FluentValidation.Validators.PredicateValidator<T, TProperty>;

namespace Application.Tests.Mocks.Repositories.Brands
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
            // It.IsAny<Brand>() => Gelecek parametre herhangi bir Brand nesnesi olabilir
            mockRepository
                .Setup(s => s.Add(It.IsAny<Brand>()))
                .Returns((Brand entity) =>
                {
                    brands.Add(entity);
                    return entity;
                });
            #endregion
            #region GetAsync Mock



            // Genelden -> özele
            mockRepository.Setup(s => s.GetAsync(
                 It.IsAny<Expression<Func<Brand, bool>>>(),
                 It.IsAny<Func<IQueryable<Brand>, IIncludableQueryable<Brand, object>>>(),
                 It.IsAny<bool>(),
                 It.IsAny<CancellationToken>()
                 )).ReturnsAsync((Expression<Func<Brand, bool>> predicate, Func<IQueryable<Brand>, IIncludableQueryable<Brand, object>>? include, bool enableTracking,
                       CancellationToken cancellationToken) =>
                 {
                     Brand brand = null;
                     if (predicate != null)
                         brand = brands.Where(predicate.Compile()).FirstOrDefault();
                     return brand;
                 });

            mockRepository.Setup(s => s.GetAsync(
                i => i.Name == "BMW",
                It.IsAny<Func<IQueryable<Brand>, IIncludableQueryable<Brand, object>>>(),
                It.IsAny<bool>(),
                It.IsAny<CancellationToken>()
                )).ReturnsAsync((Expression<Func<Brand, bool>> predicate, Func<IQueryable<Brand>, IIncludableQueryable<Brand, object>>? include, bool enableTracking,
                      CancellationToken cancellationToken) =>
                {
                    return brands[0];
                });






            #endregion
            #region GetListAsync Mock
            mockRepository.Setup(s => s.GetListAsync(
                    It.IsAny<Expression<Func<Brand, bool>>>(),
                    It.IsAny<Func<IQueryable<Brand>, IOrderedQueryable<Brand>>>(),
                    It.IsAny<Func<IQueryable<Brand>, IIncludableQueryable<Brand, object>>>(),
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<bool>(),
                    It.IsAny<CancellationToken>()
                )).ReturnsAsync((Expression<Func<Brand, bool>>? predicate,
                                    Func<IQueryable<Brand>, IOrderedQueryable<Brand>>? orderBy,
                                    Func<IQueryable<Brand>, IIncludableQueryable<Brand, object>>? include,
                                    int index, int size, bool enableTracking,
                                    CancellationToken cancellationToken) =>
                {
                    IList<Brand> brandList;
                    if (predicate != null)
                    {
                        brandList = brands.Where(predicate.Compile()).ToList();
                    }
                    else
                    {
                        brandList = brands;
                    }
                    Paginate<Brand> list = new()
                    {
                        Items = brandList,
                        Index = index,
                        Size = size
                    };
                    return list;
                });
            #endregion

            return mockRepository;
        }
    }
}
