using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using SFA.DAS.FAA.Legacy.Domain.Configuration;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories;
using SFA.DAS.FAA.Legacy.Domain.Models.HealthStatus;

namespace SFA.DAS.FAA.Legacy.Data.Repositories
{
    public class HealthStatusRepository : IHealthStatusRepository
    {
        private readonly IMongoDbConfiguration _mongoDbConfiguration;
        private readonly ILogger<HealthStatusRepository> _logger;

        public HealthStatusRepository(
            IMongoDbConfiguration mongoDbConfiguration,
            ILogger<HealthStatusRepository> logger)
        {
            _mongoDbConfiguration = mongoDbConfiguration;
            _logger = logger;
        }

        public async Task<HealthCheckResult> IsHealthy()
        {
            try
            {
                await IsMongoHealthy();
                return HealthCheckResult.Healthy;
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to communicate with MongoDb. Details: {details}", ex.Message);
                return HealthCheckResult.UnHealthy;
            }
        }

        private async Task IsMongoHealthy()
        {
            var url = new MongoUrl(_mongoDbConfiguration.ConnectionString);

            var dbInstance = new MongoClient(url)
                .GetDatabase(url.DatabaseName)
                .WithReadPreference(new ReadPreference(ReadPreferenceMode.Primary));

            _ = await dbInstance.RunCommandAsync<BsonDocument>(new BsonDocument { { "ping", 1 } });
        }
    }
}
