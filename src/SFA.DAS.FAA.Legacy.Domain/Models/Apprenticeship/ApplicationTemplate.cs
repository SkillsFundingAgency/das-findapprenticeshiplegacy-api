namespace SFA.DAS.FAA.Legacy.Domain.Models.Apprenticeship
{
    public class ApplicationTemplate
    {
        public ApplicationTemplate()
        {
            this.Qualifications = (IList<Qualification>)new List<Qualification>();
            this.WorkExperience = (IList<WorkExperience>)new List<WorkExperience>();
            this.TrainingCourses = (IList<TrainingCourse>)new List<TrainingCourse>();
            this.AboutYou = new AboutYou();
        }

        public Education EducationHistory { get; set; }

        public IList<Qualification> Qualifications { get; set; }

        public IList<WorkExperience> WorkExperience { get; set; }

        public IList<TrainingCourse> TrainingCourses { get; set; }

        public AboutYou AboutYou { get; set; }

        public DisabilityStatus? DisabilityStatus { get; set; }
    }
}
