using SFA.DAS.FAA.Legacy.Domain.Concretes;
using SFA.DAS.FAA.Legacy.Domain.Models.Apprenticeship;

namespace SFA.DAS.FAA.Legacy.Domain.Models.Candidate
{
    public class Candidate : BaseEntity
    {
        public int LegacyCandidateId { get; set; }

        public Guid SubscriberId { get; set; } = Guid.NewGuid();

        public RegistrationDetails RegistrationDetails { get; init; } = new();

        public ApplicationTemplate ApplicationTemplate { get; set; } = new();

        public CommunicationPreferences CommunicationPreferences { get; set; } = new();

        public HelpPreferences HelpPreferences { get; set; } = new();

        public MonitoringInformation MonitoringInformation { get; set; } = new();
    }
}
