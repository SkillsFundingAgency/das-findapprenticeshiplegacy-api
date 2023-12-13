using User = SFA.DAS.FAA.Legacy.Domain.Models.User.User;

namespace SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories
{
    public interface IUserReadRepository
    {
        User? Get(string username);
    }
}
