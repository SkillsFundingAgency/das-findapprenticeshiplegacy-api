using SFA.DAS.FAA.Legacy.Domain.Models.Application;

namespace SFA.DAS.FAA.Legacy.Domain.Models.Apprenticeship
{
    public class VacancyDetail
    {
        public long Ukprn { get; set; }
        public GeoPoint Location { get; set; }
        public string Category { get; set; }
        public string CategoryCode { get; set; }
        public string SubCategory { get; set; }
        public string SubCategoryCode { get; set; }
        public string AccountPublicHashedId { get; set; }
        public string AccountLegalEntityPublicHashedId { get; set; }

        public int Id { get; set; }

        public string VacancyReference { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string FullDescription { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ClosingDate { get; set; }

        public DateTime PostedDate { get; set; }

        public DateTime InterviewFromDate { get; set; }

        public string WorkingWeek { get; set; }

        public string OtherInformation { get; set; }

        public string FutureProspects { get; set; }

        public string VacancyOwner { get; set; }

        public string VacancyManager { get; set; }

        public string LocalAuthority { get; set; }

        public int NumberOfPositions { get; set; }

        public string RealityCheck { get; set; }

        public VacancyStatuses VacancyStatus { get; set; }
        public VacancyLocationType VacancyLocationType { get; set; }
        public ApprenticeshipLevel ApprenticeshipLevel { get; set; }

        public bool IsRecruitVacancy { get; set; }

        public IEnumerable<string> Skills { get; set; }

        public string WorkExperience { get; set; }

        public string EmployerName { get; set; }

        public string AnonymousEmployerName { get; set; }

        public string AnonymousAboutTheEmployer { get; set; }

        public string EmployerWebsite { get; set; }

        public bool ApplyViaEmployerWebsite { get; set; }

        public string VacancyUrl { get; set; }

        public string ApplicationInstructions { get; set; }

        public bool IsEmployerAnonymous { get; set; }

        public bool IsPositiveAboutDisability { get; set; }

        public string ExpectedDuration { get; set; }

        //public Address VacancyAddress { get; set; }
        public Address Address { get; set; }

        public string AdditionalLocationInformation { get; set; }

        public bool IsRecruitmentAgencyAnonymous { get; set; }

        public bool IsSmallEmployerWageIncentive { get; set; }

        public string SupplementaryQuestion1 { get; set; }

        public string SupplementaryQuestion2 { get; set; }

        public string RecruitmentAgency { get; set; }

        public string ProviderName { get; set; }

        public string TradingName { get; set; }

        public string ProviderDescription { get; set; }

        public string Contact { get; set; }

        public int? ProviderSectorPassRate { get; set; }

        public string TrainingToBeProvided { get; set; }

        public string ContractOwner { get; set; }

        public string DeliveryOrganisation { get; set; }

        public bool IsNasProvider { get; set; }

        public string PersonalQualities { get; set; }

        public string QualificationRequired { get; set; }
        public string SkillsRequired { get; set; }
        public bool IsDisabilityConfident { get; set; }
        public string LongDescription { get; set; }
        public string TrainingDescription { get; set; }
        public List<VacancyQualification> Qualifications { get; set; }
        public string OutcomeDescription { get; set; }
        public string EmployerContactName { get; set; }
        public string EmployerContactPhone { get; set; }
        public string EmployerContactEmail { get; set; }
        public string EmployerWebsiteUrl { get; set; }
        public string EmployerDescription { get; set; }
        public int Duration { get; set; }
        public string DurationUnit { get; set; }
        public string ThingsToConsider { get; set; }
    }
}
