using SFA.DAS.FAA.Legacy.Domain.Models.HealthStatus;

namespace SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories
{
    public interface IHealthStatusRepository
    {
        Task<HealthCheckResult> IsHealthy();
    }
}
