namespace SFA.DAS.FAA.Legacy.Domain.Models.Candidate
{
    public class CommunicationPreferences
    {
        public bool VerifiedMobile { get; set; } = false;

        public string MobileVerificationCode { get; set; } = string.Empty;

        public DateTime? MobileVerificationCodeDateCreated { get; set; } = new();

        public bool AllowTraineeshipPrompts { get; set; } = true;

        public CommunicationPreference ApplicationStatusChangePreferences { get; set; } = new()
        {
            EnableEmail = true,
            EnableText = true
        };

        public CommunicationPreference ExpiringApplicationPreferences { get; set; } = new()
        {
            EnableEmail = true,
            EnableText = true
        };

        public CommunicationPreference SavedSearchPreferences { get; set; } = new()
        {
            EnableEmail = true,
            EnableText = false
        };

        public CommunicationPreference MarketingPreferences { get; set; } = new()
        {
            EnableEmail = true,
            EnableText = true
        };
    }
}
