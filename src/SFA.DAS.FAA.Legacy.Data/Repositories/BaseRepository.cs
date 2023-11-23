using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using SFA.DAS.FAA.Legacy.Data.Concretes;
using SFA.DAS.FAA.Legacy.Domain.Concretes;
using SFA.DAS.FAA.Legacy.Domain.Configuration;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories;

namespace SFA.DAS.FAA.Legacy.Data.Repositories
{
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
            _collection = _mongoDatabase.GetCollection<TEntity>(BaseRepository<TEntity>.GetCollectionName(typeof(TEntity)));
        }

        private protected static string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }

        public async Task Ping()
        {
            _ = await _mongoDatabase.RunCommandAsync<BsonDocument>(new BsonDocument { { "ping", 1 } });
        }

        public virtual IQueryable<TEntity> AsQueryable()
        {
            return _collection.AsQueryable();
        }

        public virtual IEnumerable<TEntity> FilterBy(
            Expression<Func<TEntity, bool>> filterExpression)
        {
            return _collection.Find(filterExpression).ToEnumerable();
        }

        public virtual IEnumerable<TProjected> FilterBy<TProjected>(
            Expression<Func<TEntity, bool>> filterExpression,
            Expression<Func<TEntity, TProjected>> projectionExpression)
        {
            return _collection.Find(filterExpression).Project(projectionExpression).ToEnumerable();
        }

        public virtual TEntity FindOne(Expression<Func<TEntity, bool>> filterExpression)
        {
            return _collection.Find(filterExpression).FirstOrDefault();
        }

        public virtual Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> filterExpression)
        {
            return Task.Run(() => _collection.Find(filterExpression).FirstOrDefaultAsync());
        }

        public virtual TEntity FindById(string id)
        {
            var objectId = new Guid(id);
            var filter = Builders<TEntity>.Filter.Eq(doc => doc.EntityId, objectId);
            return _collection.Find(filter).SingleOrDefault();
        }

        public virtual Task<TEntity> FindByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                var objectId = new Guid(id);
                var filter = Builders<TEntity>.Filter.Eq(doc => doc.EntityId, objectId);
                return _collection.Find(filter).SingleOrDefaultAsync();
            });
        }


        public virtual void InsertOne(TEntity document)
        {
            _collection.InsertOne(document);
        }

        public virtual Task InsertOneAsync(TEntity document)
        {
            return Task.Run(() => _collection.InsertOneAsync(document));
        }

        public void InsertMany(ICollection<TEntity> documents)
        {
            _collection.InsertMany(documents);
        }


        public virtual async Task InsertManyAsync(ICollection<TEntity> documents)
        {
            await _collection.InsertManyAsync(documents);
        }

        public void ReplaceOne(TEntity document)
        {
            var filter = Builders<TEntity>.Filter.Eq(doc => doc.EntityId, document.EntityId);
            _collection.FindOneAndReplace(filter, document);
        }

        public virtual async Task ReplaceOneAsync(TEntity document)
        {
            var filter = Builders<TEntity>.Filter.Eq(doc => doc.EntityId, document.EntityId);
            await _collection.FindOneAndReplaceAsync(filter, document);
        }

        public void DeleteOne(Expression<Func<TEntity, bool>> filterExpression)
        {
            _collection.FindOneAndDelete(filterExpression);
        }

        public Task DeleteOneAsync(Expression<Func<TEntity, bool>> filterExpression)
        {
            return Task.Run(() => _collection.FindOneAndDeleteAsync(filterExpression));
        }

        public void DeleteById(string id)
        {
            var objectId = new Guid(id);
            var filter = Builders<TEntity>.Filter.Eq(doc => doc.EntityId, objectId);
            _collection.FindOneAndDelete(filter);
        }

        public Task DeleteByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                var objectId = new Guid(id);
                var filter = Builders<TEntity>.Filter.Eq(doc => doc.EntityId, objectId);
                _collection.FindOneAndDeleteAsync(filter);
            });
        }

        public void DeleteMany(Expression<Func<TEntity, bool>> filterExpression)
        {
            _collection.DeleteMany(filterExpression);
        }

        public Task DeleteManyAsync(Expression<Func<TEntity, bool>> filterExpression)
        {
            return Task.Run(() => _collection.DeleteManyAsync(filterExpression));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
