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

        public static implicit operator GetUserByEmailResult(Domain.Models.User.User user)
        {
            return new GetUserByEmailResult
            {
                Username = user.Username,
                AccountUnlockCode = user.AccountUnlockCode,
                ActivationCode = user.ActivationCode,
                AccountUnlockCodeExpiry = user.AccountUnlockCodeExpiry,
                LastActivity = user.LastActivity,
                PendingUsername = user.PendingUsername,
                ActivateCodeExpiry = user.ActivateCodeExpiry,
                ActivationDate = user.ActivationDate,
                LastLogin = user.LastLogin,
                LoginIncorrectAttempts = user.LoginIncorrectAttempts,
                PasswordResetCode = user.PasswordResetCode,
                PasswordResetCodeExpiry = user.PasswordResetCodeExpiry,
                PasswordResetIncorrectAttempts = user.PasswordResetIncorrectAttempts,
                PendingUsernameCode = user.PendingUsernameCode,
                Roles = user.Roles,
                Status = user.Status
            };
        }
    }
}
