using SFA.DAS.FAA.Legacy.Domain.Models.Candidate;

namespace SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories
{
    public interface ICandidateReadRepository
    {
        Candidate? Get(string username);
    }
}
