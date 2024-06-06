using SFA.DAS.FAA.Legacy.Domain.Models.Apprenticeship;
using SFA.DAS.FAA.Legacy.Domain.Models.Candidate;
using SFA.DAS.FAA.Legacy.Domain.Models.User;

namespace SFA.DAS.FAA.Legacy.Application.User.Queries
{
    public class GetUserByEmailResult
    {
        public string? Username { get; init; }

        public UserStatuses Status { get; init; }

        public UserRoles Roles { get; init; }

        public string? ActivationCode { get; init; }

        public DateTime? ActivateCodeExpiry { get; init; }

        public DateTime? ActivationDate { get; init; }

        public int LoginIncorrectAttempts { get; init; }

        public string? PasswordResetCode { get; init; }

        public DateTime? PasswordResetCodeExpiry { get; init; }

        public int PasswordResetIncorrectAttempts { get; init; }

        public string? AccountUnlockCode { get; init; }

        public DateTime? AccountUnlockCodeExpiry { get; init; }

        public DateTime? LastLogin { get; init; }

        public DateTime LastActivity { get; init; }

        public string? PendingUsername { get; init; }
       
        public string? PendingUsernameCode { get; init; }

        public RegistrationDetails? RegistrationDetails { get; init; }

        public CommunicationPreferences? CommunicationPreferences { get; init; }
    }
}
