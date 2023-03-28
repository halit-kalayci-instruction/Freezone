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
    public static class MockRefreshTokenRepository
    {
        public static Mock<IRefreshTokenRepository> GetRefreshTokenRepositoryMock()
        {
            List<RefreshToken> tokens = new List<RefreshToken>()
            {
                new(){ UserId=1, Token="abc"}
            };
            var mockRepo = new Mock<IRefreshTokenRepository>();
            mockRepo.Setup(s => s.GetAllOldActiveRefreshTokensAsync(It.IsAny<User>(), It.IsAny<int>())).ReturnsAsync((User user, int ttl) =>
            {
                return tokens.Where(i=>i.UserId == user.Id).ToList();
            });
            return mockRepo;
        }
    }
}
