using SFA.DAS.FAA.Legacy.Domain.Interfaces.Configuration;

namespace SFA.DAS.FAA.Legacy.Domain.Configuration
{
    public class MongoConfiguration : IMongoConfiguration
    {
        public string? AzureCosmosDb { get; set; }
    }
}
