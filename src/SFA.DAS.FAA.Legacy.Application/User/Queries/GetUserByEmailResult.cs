using SFA.DAS.FAA.Legacy.Domain.Concretes.User;

namespace SFA.DAS.FAA.Legacy.Application.User.Queries
{
    public class GetUserByEmailResult
    {
        public string? Username { get; set; }

        public UserStatuses Status { get; set; }

        public UserRoles Roles { get; set; }

        public string? ActivationCode { get; set; }

        public DateTime? ActivateCodeExpiry { get; set; }

        public DateTime? ActivationDate { get; set; }

        public int LoginIncorrectAttempts { get; set; }

        public string? PasswordResetCode { get; set; }

        public DateTime? PasswordResetCodeExpiry { get; set; }

        public int PasswordResetIncorrectAttempts { get; set; }

        public string? AccountUnlockCode { get; set; }

        public DateTime? AccountUnlockCodeExpiry { get; set; }

        public DateTime? LastLogin { get; set; }

        public DateTime LastActivity { get; set; }

        public string? PendingUsername { get; set; }
       
        public string? PendingUsernameCode { get; set; }

        public static implicit operator GetUserByEmailResult?(Domain.Concretes.User.User? user)
        {
            if (user is null)
                return null;

            GetUserByEmailResult getUserByEmailResult = new()
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

            return getUserByEmailResult;
        }
    }
}
