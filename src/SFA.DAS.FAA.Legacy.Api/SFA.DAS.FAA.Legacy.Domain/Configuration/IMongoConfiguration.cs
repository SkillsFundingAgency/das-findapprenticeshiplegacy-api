namespace SFA.DAS.FAA.Legacy.Domain.Configuration
{
    public interface IMongoDbConfiguration
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
