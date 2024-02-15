using SFA.DAS.FAA.Legacy.Domain.Models.Apprenticeship;

namespace SFA.DAS.FAA.Legacy.Domain.Models.Candidate
{
    public class MonitoringInformation
    {
        public Gender? Gender { get; set; }

        public DisabilityStatus? DisabilityStatus { get; set; }

        public int? Ethnicity { get; set; }
    }
}
