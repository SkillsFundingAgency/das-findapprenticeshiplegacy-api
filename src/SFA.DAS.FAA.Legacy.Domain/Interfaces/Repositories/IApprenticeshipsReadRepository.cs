using SFA.DAS.FAA.Legacy.Domain.Models.Application;

namespace SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories
{
    public interface IApprenticeshipsReadRepository
    {
        IEnumerable<Apprenticeship> Get(string username);
    }
}
