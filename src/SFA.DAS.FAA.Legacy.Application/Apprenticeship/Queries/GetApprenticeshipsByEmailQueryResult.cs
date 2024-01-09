using SFA.DAS.FAA.Legacy.Domain.Models.Application;
using SFA.DAS.FAA.Legacy.Domain.Models.Apprenticeship;

namespace SFA.DAS.FAA.Legacy.Application.Apprenticeship.Queries;

public record GetApprenticeshipsByEmailQueryResult
{
    public int Count { get; init; }
    public List<ApprenticeshipResult>? Apprenticeships { get; init; }
}

public record ApprenticeshipResult
{
    public VacancyStatuses VacancyStatus { get; init; }
    public ApplicationStatuses Status { get; init; }
    public DateTime? DateApplied { get; init; }
    public DateTime? DateCreated { get; init; }
    public DateTime? DateUpdated { get; init; }
    public DateTime? SuccessfulDateTime { get; init; }
    public DateTime? UnsuccessfulDateTime { get; init; }
    public DateTime? DateLastViewed { get; init; }
    public bool IsArchived { get; set; }
    public int LegacyApplicationId { get; init; }
    public string? AdditionalQuestion1Answer { get; init; }
    public string? AdditionalQuestion2Answer { get; init; }
    public string? Notes { get; init; }
    public string? UnsuccessfulReason { get; init; }
    public string? WithdrawnOrDeclinedReason { get; init; }
    public List<string>? Skills { get; init; }
    public Guid CandidateId { get; init; }
    public RegistrationDetails? CandidateDetails { get; init; }
    public ApplicationTemplate? CandidateInformation { get; init; }
    public VacancyDetail? Vacancy { get; init; }

    public static implicit operator ApprenticeshipResult(Domain.Models.Application.Apprenticeship source)
    {
        return new ApprenticeshipResult
        {
            Status = source.Status,
            AdditionalQuestion1Answer = source.AdditionalQuestion1Answer,
            AdditionalQuestion2Answer = source.AdditionalQuestion2Answer,
            DateCreated = source.DateCreated,
            DateLastViewed = source.DateLastViewed,
            LegacyApplicationId = source.LegacyApplicationId,
            Notes = source.Notes,
            UnsuccessfulReason = source.UnsuccessfulReason,
            VacancyStatus = source.VacancyStatus,
            DateUpdated = source.DateUpdated,
            DateApplied = source.DateApplied,
            CandidateDetails = source.CandidateDetails,
            WithdrawnOrDeclinedReason = source.WithdrawnOrDeclinedReason,
            Vacancy = source.Vacancy,
            CandidateId = source.CandidateId,
            CandidateInformation = source.CandidateInformation,
            Skills = source.Skills,
            SuccessfulDateTime = source.SuccessfulDateTime,
            UnsuccessfulDateTime = source.UnsuccessfulDateTime,
            IsArchived = source.IsArchived
        };
    }
}