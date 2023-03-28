using Application.Services.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Mocks.Repositories.Auth
{
    public static class MockUserTitleDefinitionRepository
    {
        public static Mock<IUserTitleDefinitonRepository> GetUserTitleDefinitionMock()
        {
            var mockRepo = new Mock<IUserTitleDefinitonRepository>();
            return mockRepo;
        }
    }
}
