using SFA.DAS.FAA.Legacy.Domain.Models.Application;

namespace SFA.DAS.FAA.Legacy.Domain.Models.Apprenticeship;

public record VacancyDetail
{
    public int Id { get; init; }
    public long Ukprn { get; init; }
    public string? Category { get; init; }
    public string? CategoryCode { get; init; }
    public string? SubCategory { get; init; }
    public string? SubCategoryCode { get; init; }
    public string? AccountPublicHashedId { get; init; }
    public string? AccountLegalEntityPublicHashedId { get; init; }
    public string? VacancyReference { get; init; }
    public string? Title { get; init; }
    public string? Description { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime ClosingDate { get; init; }
    public DateTime PostedDate { get; init; }
    public string? WorkingWeek { get; init; }
    public VacancyStatuses VacancyStatus { get; init; }
    public VacancyLocationType VacancyLocationType { get; init; }
    public ApprenticeshipLevel ApprenticeshipLevel { get; init; }
    public IEnumerable<string>? Skills { get; init; }
    public bool IsRecruitVacancy { get; init; }
    public bool IsPositiveAboutDisability { get; init; }
    public bool IsEmployerAnonymous { get; init; }
    public string? AnonymousEmployerName { get; init; }
    public int NumberOfPositions { get; init; }
    public string? ProviderName { get; init; }
    public string? QualificationRequired { get; init; }
    public string? SkillsRequired { get; init; }
    public bool IsDisabilityConfident { get; init; }
    public string? LongDescription { get; init; }
    public string? TrainingDescription { get; init; }
    public string? OutcomeDescription { get; init; }
    public string? EmployerContactName { get; init; }
    public string? EmployerContactPhone { get; init; }
    public string? EmployerContactEmail { get; init; }
    public string? EmployerWebsiteUrl { get; init; }
    public string? EmployerDescription { get; init; }
    public int Duration { get; init; }
    public string? DurationUnit { get; init; }
    public string? ThingsToConsider { get; init; }
    public string? EmployerName { get; init; }
    public bool ApplyViaEmployerWebsite { get; init; }
    public string? ExpectedDuration { get; init; }
    public GeoPoint Location { get; init; } = new();
    public List<VacancyQualification> Qualifications { get; init; } = new();
    public Address Address { get; init; } = new();
}