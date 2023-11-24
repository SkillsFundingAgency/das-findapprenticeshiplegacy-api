using MongoDB.Driver;
using System.Linq.Expressions;

namespace SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task Ping();

        IEnumerable<TEntity> FilterBy(
            Expression<Func<TEntity, bool>> filterExpression, SortDefinition<TEntity> sortDefinition);
        
    }
}
