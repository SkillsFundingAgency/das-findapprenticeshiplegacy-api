namespace SFA.DAS.FAA.Legacy.Domain.Models.Apprenticeship;

public record TrainingCourse
{
    public string? Provider { get; set; }

    public string? Title { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }
}