using Application.Services.Repositories;
using Domain.Entities;
using Freezone.Core.Security.Authenticator;
using Freezone.Core.Security.Entities;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Mocks.Repositories.Auth
{
    public static class MockUserRepository
    {
        //TDD 
        public static Mock<IUserRepository> GetUserRepositoryMock()
        {
            var userList = new List<User>()
            {
                new(){ Id = 1, AuthenticatorType=AuthenticatorType.None, Email="halit@kodlama.io", FirstName="Halit", LastName="Kalaycı" },
                new(){ Id = 2, AuthenticatorType=AuthenticatorType.None, Email="engin@kodlama.io", FirstName="Engin", LastName="Demiroğ" },
            };
            var mockRepo = new Mock<IUserRepository>();
            #region GetAsync Mock
            mockRepo.Setup(s => s.GetAsync(
               It.IsAny<Expression<Func<User, bool>>>(),
               It.IsAny<Func<IQueryable<User>, IIncludableQueryable<User, object>>>(),
               It.IsAny<bool>(),
               It.IsAny<CancellationToken>()
               ))
               .ReturnsAsync((Expression<Func<User, bool>> predicate, Func<IQueryable<User>, IIncludableQueryable<User, object>>? include, bool enableTracking, CancellationToken cancellationToken) =>
               {
                   User user = null;
                   if (predicate != null)
                       user = userList.Where(predicate.Compile()).FirstOrDefault();
                   return user;
               });
            #endregion
            return mockRepo;
        }
    }
}
