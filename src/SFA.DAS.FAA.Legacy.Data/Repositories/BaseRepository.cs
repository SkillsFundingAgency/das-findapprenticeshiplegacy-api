using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using SFA.DAS.FAA.Legacy.Data.Concretes;
using SFA.DAS.FAA.Legacy.Domain.Concretes;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Configuration;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories;

namespace SFA.DAS.FAA.Legacy.Data.Repositories
{
    [ExcludeFromCodeCoverage]
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IMongoCollection<TEntity> _collection;
        private readonly IMongoDatabase _mongoDatabase;

        protected BaseRepository(IMongoConfiguration mongoConfiguration)
        {
            var mongoConnectionString = mongoConfiguration.AzureCosmosDb;
            var mongoDbName = MongoUrl.Create(mongoConnectionString).DatabaseName;
            _mongoDatabase = new MongoClient(mongoConnectionString)
                .GetDatabase(mongoDbName);
            _collection = _mongoDatabase.GetCollection<TEntity>(GetCollectionName(typeof(TEntity)));
        }

        private static string? GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault()!).CollectionName;
        }

        public async Task Ping()
        {
            _ = await _mongoDatabase.RunCommandAsync<BsonDocument>(new BsonDocument { { "ping", 1 } });
        }

        public virtual IEnumerable<TEntity> FilterBy(
            Expression<Func<TEntity, bool>> filterExpression, SortDefinition<TEntity>? sortDefinition = null)
        {
            return _collection
                .Find(filterExpression)
                .Sort(sortDefinition)
                .ToEnumerable();
        }
    }
}
