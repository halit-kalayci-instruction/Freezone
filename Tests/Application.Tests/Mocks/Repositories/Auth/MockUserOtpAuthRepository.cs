using Application.Services.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Mocks.Repositories.Auth
{
    public static class MockUserOtpAuthRepository
    {
        public static Mock<IUserOtpAuthenticatorRepository> GetUserOtpAuthenticatorMock()
        {
            var mockRepo = new Mock<IUserOtpAuthenticatorRepository>();
            return mockRepo;
        }
    }
}
