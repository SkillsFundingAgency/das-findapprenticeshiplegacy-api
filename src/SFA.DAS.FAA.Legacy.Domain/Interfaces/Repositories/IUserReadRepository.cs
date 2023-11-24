using User = SFA.DAS.FAA.Legacy.Domain.Concretes.User.User;

namespace SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories
{
    public interface IUserReadRepository
    {
        Task<User> Get(string username);
    }
}
