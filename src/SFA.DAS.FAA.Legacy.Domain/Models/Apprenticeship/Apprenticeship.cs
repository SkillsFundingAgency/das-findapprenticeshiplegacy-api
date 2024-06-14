using SFA.DAS.FAA.Legacy.Domain.Concretes;
using SFA.DAS.FAA.Legacy.Domain.Models.Apprenticeship;

namespace SFA.DAS.FAA.Legacy.Domain.Models.Application;

public class Apprenticeship : BaseEntity
{
    public VacancyStatuses VacancyStatus { get; init; }

    public ApplicationStatuses Status { get; init; }

    public bool IsArchived { get; init; }

    public DateTime? DateApplied { get; init; }

    public Guid CandidateId { get; init; }

    public int LegacyApplicationId { get; init; }

    public RegistrationDetails CandidateDetails { get; init; } = new();

    public ApplicationTemplate CandidateInformation { get; init; } = new();

    public string? AdditionalQuestion1Answer { get; init; }

    public string? AdditionalQuestion2Answer { get; init; }

    public DateTime? DateLastViewed { get; init; }

    public string? Notes { get; init; }

    public List<string>? Skills { get; init; }

    public DateTime? SuccessfulDateTime { get; init; }

    public DateTime? UnsuccessfulDateTime { get; init; }

    public string? UnsuccessfulReason { get; init; }

    public string? WithdrawnOrDeclinedReason { get; init; }

    public VacancyDetail? Vacancy { get; init; }
    public Guid ApplicationId { get; set; }
}