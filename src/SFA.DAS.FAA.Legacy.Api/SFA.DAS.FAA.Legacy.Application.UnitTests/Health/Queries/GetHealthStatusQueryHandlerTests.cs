using AutoFixture.NUnit3;
using FluentAssertions;
using Moq;
using SFA.DAS.FAA.Legacy.Application.Health.Queries;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories;
using SFA.DAS.FAA.Legacy.Domain.Models.HealthStatus;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.FAA.Legacy.Application.UnitTests.Health.Queries
{
    public class GetHealthStatusQueryHandlerTests
    {
        [Test]
        [RecursiveMoqAutoData]
        public async Task Handle_GetHealthStatusHandler_ReturnsHealthCheckResult(
            [Frozen] Mock<IHealthStatusRepository> healthStatusRepositoryMock,
            GetHealthStatusQueryHandler sut,
            HealthCheckResult healthCheckResult)
        {
            healthStatusRepositoryMock.Setup(a => a.HealthCheck()).ReturnsAsync(healthCheckResult);

            var result = await sut.Handle(new GetHealthStatusQuery(), new CancellationToken());

            result.Status.Should().BeEquivalentTo(healthCheckResult.ToString());
        }
    }
}
