using Application.Services.Repositories;
using Moq;

namespace Application.Tests.Mocks.Repositories.Auth
{
    public static class MockTitleOperationClaimRepository
    {
        public static Mock<ITitleOperationClaimRepository> GetTitleOperationClaimMock()
        {
            var mockRepo = new Mock<ITitleOperationClaimRepository>();
            return mockRepo;
        }
    }
}
