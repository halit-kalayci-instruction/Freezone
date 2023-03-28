using Application.Services.Repositories;
using Freezone.Core.Security.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Mocks.Repositories.Auth
{
    public static class MockUserOperationClaimRepository
    {
        public static Mock<IUserOperationClaimRepository> GetUserOperationClaimRepositoryMock()
        {
            var operationClaims = new List<OperationClaim>()
            {
                new(){ Id=1, Name="Admin",Status=1 },
                new(){ Id=2, Name="Brands.Create",Status=1 },
                new(){ Id=3, Name="Brands.Delete",Status=1 },
                new(){ Id=4, Name="Brands.Update",Status=1 },
                new(){ Id=5, Name="Moderator",Status=1 },
            };
            var mockRepo = new Mock<IUserOperationClaimRepository>();

            //mockRepo.Setup(s => s.GetOperationClaimsByUserIdAsync(It.IsAny<int>()))
            //        .ReturnsAsync((int userId) =>
            //        {
            //            var claims = operationClaims.Where(i => i.UserId == userId);
            //            return claims;
            //        });

            mockRepo.Setup(s => s.GetOperationClaimsByUserIdAsync(It.IsAny<int>())).Returns((int userId) =>
            {
                var claims = operationClaims.ToList();
                return Task.FromResult(claims as ICollection<OperationClaim>);
            });


            return mockRepo;
        }
    }
}
