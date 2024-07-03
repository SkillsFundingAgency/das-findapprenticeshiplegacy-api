using SFA.DAS.FAA.Legacy.Domain.Models.User;

namespace SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories
{
    public interface IAuthenticationRepository
    {
        UserCredentials? Get(Guid id);
    }
}
