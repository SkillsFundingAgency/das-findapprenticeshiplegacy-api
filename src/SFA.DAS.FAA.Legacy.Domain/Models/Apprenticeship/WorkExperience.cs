namespace SFA.DAS.FAA.Legacy.Domain.Models.Apprenticeship
{
    public class WorkExperience
    {
        public string Employer { get; set; }

        public string JobTitle { get; set; }

        public string Description { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }
    }
}
