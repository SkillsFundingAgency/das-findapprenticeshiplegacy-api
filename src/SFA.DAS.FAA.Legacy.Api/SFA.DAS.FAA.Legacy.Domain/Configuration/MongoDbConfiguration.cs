namespace SFA.DAS.FAA.Legacy.Domain.Configuration
{
    public class MongoDbConfiguration : IMongoDbConfiguration
    {
        public string? ConnectionString { get; set; }
    }
}
