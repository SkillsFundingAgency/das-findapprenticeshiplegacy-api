using AutoFixture.NUnit3;
using FluentAssertions;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Moq;
using SFA.DAS.FAA.Legacy.Api.HealthCheck;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.FAA.Legacy.Api.UnitTests.HealthCheck;

public class WhenGettingMongoDbHealth
{
    [Test, MoqAutoData]
    public async Task Then_Healthy_Returned_If_Returns_Healthy_From_Repository(
        HealthCheckContext context,
        [Frozen] Mock<IHealthStatusRepository> healthStatusRepository,
        MongoHealthCheck healthCheck)
    {
        healthStatusRepository.Setup(x => x.HealthCheck())
            .ReturnsAsync(Domain.Models.HealthStatus.HealthCheckResult.UnHealthy);
        
        var actual = await healthCheck.CheckHealthAsync(context);

        actual.Status.Should().Be(HealthStatus.Unhealthy);
    }
    [Test, MoqAutoData]
    public async Task Then_UnHealthy_Returned_If_Returns_UnHealthy_From_Repository(
        HealthCheckContext context,
        [Frozen] Mock<IHealthStatusRepository> healthStatusRepository,
        MongoHealthCheck healthCheck)
    {
        healthStatusRepository.Setup(x => x.HealthCheck())
            .ReturnsAsync(Domain.Models.HealthStatus.HealthCheckResult.Healthy);
        
        var actual = await healthCheck.CheckHealthAsync(context);

        actual.Status.Should().Be(HealthStatus.Healthy);
    }
}