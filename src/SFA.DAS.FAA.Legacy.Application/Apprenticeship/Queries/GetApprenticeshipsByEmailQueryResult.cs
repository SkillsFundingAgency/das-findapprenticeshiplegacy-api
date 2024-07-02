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
    public VacancyStatuses VacancyStatus { get; private init; }
    public ApplicationStatuses Status { get; private init; }
    public DateTime? DateApplied { get; private init; }
    public DateTime? DateCreated { get; private init; }
    public DateTime? DateUpdated { get; private init; }
    public DateTime? SuccessfulDateTime { get; private init; }
    public DateTime? UnsuccessfulDateTime { get; private init; }
    public DateTime? DateLastViewed { get; private init; }
    public bool IsArchived { get; private init; }
    public int LegacyApplicationId { get; private init; }
    public string? AdditionalQuestion1Answer { get; private init; }
    public string? AdditionalQuestion2Answer { get; private init; }
    public string? Notes { get; private init; }
    public string? UnsuccessfulReason { get; private init; }
    public string? WithdrawnOrDeclinedReason { get; private init; }
    public List<string>? Skills { get; private init; }
    public Guid CandidateId { get; private init; }
    public RegistrationDetails? CandidateDetails { get; private init; }
    public ApplicationTemplate? CandidateInformation { get; private init; }
    public VacancyDetail? Vacancy { get; private init; }
    public Guid Id { get; set; }

    public static implicit operator ApprenticeshipResult(Domain.Models.Application.Apprenticeship source)
    {
        return new ApprenticeshipResult
        {
            Id= source.ApplicationId,
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