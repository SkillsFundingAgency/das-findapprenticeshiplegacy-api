using MongoApprenticeships = SFA.DAS.FAA.Legacy.Domain.Models.Application.Apprenticeships;

namespace SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories
{
    public interface IApprenticeshipsReadRepository
    {
        IEnumerable<MongoApprenticeships> Get(string username);
    }
}
