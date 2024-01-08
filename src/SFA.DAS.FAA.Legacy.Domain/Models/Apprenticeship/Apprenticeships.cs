using SFA.DAS.FAA.Legacy.Domain.Concretes;
using SFA.DAS.FAA.Legacy.Domain.Models.Apprenticeship;

namespace SFA.DAS.FAA.Legacy.Domain.Models.Application
{
    public class Apprenticeships : BaseEntity
    {
        public Apprenticeships()
        {
            this.CandidateDetails = new RegistrationDetails();
            this.CandidateInformation = new ApplicationTemplate();
        }

        public VacancyStatuses VacancyStatus { get; init; }

        public ApplicationStatuses Status { get; init; }

        public bool IsArchived { get; set; }

        public DateTime? DateApplied { get; init; }

        public Guid CandidateId { get; init; }

        public int LegacyApplicationId { get; init; }

        public RegistrationDetails CandidateDetails { get; init; }

        public ApplicationTemplate CandidateInformation { get; init; }

        public string AdditionalQuestion1Answer { get; init; }

        public string AdditionalQuestion2Answer { get; init; }

        public DateTime? DateLastViewed { get; init; }

        public string Notes { get; init; }

        public List<string> Skills { get; init; }

        public DateTime? SuccessfulDateTime { get; init; }

        public DateTime? UnsuccessfulDateTime { get; init; }

        public string UnsuccessfulReason { get; init; }

        public string WithdrawnOrDeclinedReason { get; init; }

        public VacancyDetail Vacancy { get; init; }
    }
}
