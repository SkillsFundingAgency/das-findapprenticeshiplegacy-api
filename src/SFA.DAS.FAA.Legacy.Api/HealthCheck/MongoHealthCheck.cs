using Microsoft.Extensions.Diagnostics.HealthChecks;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories;

namespace SFA.DAS.FAA.Legacy.Api.HealthCheck;

public class MongoHealthCheck : IHealthCheck
{
    private readonly IHealthStatusRepository _healthStatusRepository;
    private const string HealthCheckResultDescription = "Mongo DataBase connection";

    public MongoHealthCheck(IHealthStatusRepository healthStatusRepository)
    {
        _healthStatusRepository = healthStatusRepository;
    }
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _healthStatusRepository.HealthCheck();

        return result == Domain.Models.HealthStatus.HealthCheckResult.Healthy ? HealthCheckResult.Healthy(HealthCheckResultDescription) : HealthCheckResult.Unhealthy(HealthCheckResultDescription);
        
    }
}