namespace SFA.DAS.FAA.Legacy.Domain.Models.Candidate
{
    public class CommunicationPreferences
    {
        public bool VerifiedMobile { get; set; }

        public string MobileVerificationCode { get; set; }

        public DateTime? MobileVerificationCodeDateCreated { get; set; }

        public bool AllowTraineeshipPrompts { get; set; }

        public CommunicationPreference ApplicationStatusChangePreferences { get; set; }

        public CommunicationPreference ExpiringApplicationPreferences { get; set; }

        public CommunicationPreference SavedSearchPreferences { get; set; }

        public CommunicationPreference MarketingPreferences { get; set; }

        public CommunicationPreferences()
        {
            VerifiedMobile = false;
            MobileVerificationCode = string.Empty;
            MobileVerificationCodeDateCreated = null;
            AllowTraineeshipPrompts = true;
            ApplicationStatusChangePreferences = new CommunicationPreference
            {
                EnableEmail = true,
                EnableText = true
            };
            ExpiringApplicationPreferences = new CommunicationPreference
            {
                EnableEmail = true,
                EnableText = true
            };
            SavedSearchPreferences = new CommunicationPreference
            {
                EnableEmail = true,
                EnableText = false
            };
            MarketingPreferences = new CommunicationPreference
            {
                EnableEmail = true,
                EnableText = true
            };
        }
    }

    public class CommunicationPreference
    {
        public bool EnableEmail { get; set; }
        public bool EnableText { get; set; }
    }
}
