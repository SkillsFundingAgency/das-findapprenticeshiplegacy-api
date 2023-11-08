using SFA.DAS.FAA.Legacy.Domain.Models.HealthStatus;

namespace SFA.DAS.FAA.Legacy.Application.Health.Queries
{
    public class GetHealthStatusResult
    {
        public HealthCheckResult Status { get; set; }

        public static implicit operator GetHealthStatusResult(HealthCheckResult result) => new()
        {
            Status = result
        };
    }
}
