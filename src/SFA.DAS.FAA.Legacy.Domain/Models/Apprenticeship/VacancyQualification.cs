namespace SFA.DAS.FAA.Legacy.Domain.Models.Apprenticeship;

public record VacancyQualification
{
    public string? QualificationType { get; set; }

    public string? Subject { get; set; }

    public string? Grade { get; set; }

    public string? Weighting { get; set; }
}