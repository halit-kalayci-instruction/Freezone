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
    public static class MockUserEmailAuthenticatorRepository
    {
        public static Mock<IUserEmailAuthenticatorRepository> GetUserEmailAuthenticatorRepositoryMock()
        {
            var mockRepo = new Mock<IUserEmailAuthenticatorRepository>();
            return mockRepo;
        }
    }
}
