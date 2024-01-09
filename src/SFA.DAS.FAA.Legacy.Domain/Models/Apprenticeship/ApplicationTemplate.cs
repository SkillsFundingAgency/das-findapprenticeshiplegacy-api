namespace SFA.DAS.FAA.Legacy.Domain.Models.Apprenticeship;

public record ApplicationTemplate
{
    public Education? EducationHistory { get; set; }

    public IList<Qualification> Qualifications { get; set; } = new List<Qualification>();

    public IList<WorkExperience> WorkExperience { get; set; } = new List<WorkExperience>();

    public IList<TrainingCourse> TrainingCourses { get; set; } = new List<TrainingCourse>();

    public AboutYou AboutYou { get; set; } = new AboutYou();

    public DisabilityStatus? DisabilityStatus { get; set; }
}