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
            var operationClaims = new List<UserOperationClaim>()
            {
                new(){ Id=1,OperationClaimId=1, UserId=1,Status=1 },
                new(){ Id=2,OperationClaimId=2, UserId=1,Status=1 },
                new(){ Id=3,OperationClaimId=1, UserId=2,Status=1 },
                new(){ Id=4,OperationClaimId=4, UserId=2,Status=1 },
                new(){ Id=5,OperationClaimId=5, UserId=5,Status=1 },
            };
            var mockRepo = new Mock<IUserOperationClaimRepository>();

            mockRepo.Setup(s => s.GetOperationClaimsByUserIdAsync(It.IsAny<int>()))
                    .Returns((int userId) =>
                    {
                        return operationClaims.Where(i=>i.UserId == userId).ToList();
                    });

            return mockRepo;
        }
    }
}
