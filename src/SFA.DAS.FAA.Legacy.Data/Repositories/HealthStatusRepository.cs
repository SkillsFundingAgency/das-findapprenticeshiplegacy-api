using Microsoft.Extensions.Logging;
using SFA.DAS.FAA.Legacy.Data.User.Entities;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Configuration;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories;
using SFA.DAS.FAA.Legacy.Domain.Models.HealthStatus;

namespace SFA.DAS.FAA.Legacy.Data.Repositories
{
    public class HealthStatusRepository : BaseRepository<MongoUser>, IHealthStatusRepository
    {
        private readonly ILogger<HealthStatusRepository> _logger;

        public HealthStatusRepository(
            IMongoConfiguration mongoConfiguration,
            ILogger<HealthStatusRepository> logger) 
            : base(mongoConfiguration)
        {
            _logger = logger;
        }

        public async Task<HealthCheckResult> HealthCheck()
        {
            try
            {
                await Ping();
                return HealthCheckResult.Healthy;
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to communicate with MongoDb. Details: {details}", ex.Message);
                return HealthCheckResult.UnHealthy;
            }
        }
    }
}
