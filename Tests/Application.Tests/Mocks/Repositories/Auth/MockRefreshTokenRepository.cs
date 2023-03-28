using Application.Services.Repositories;
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
            var mockRepo = new Mock<IRefreshTokenRepository>();

            return mockRepo;
        }
    }
}
