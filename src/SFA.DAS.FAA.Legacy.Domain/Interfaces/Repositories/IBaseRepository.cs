namespace SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task Ping();
    }
}
