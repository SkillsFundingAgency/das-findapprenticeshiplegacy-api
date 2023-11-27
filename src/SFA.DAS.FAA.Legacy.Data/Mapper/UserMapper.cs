using SFA.DAS.FAA.Legacy.Data.User.Entities;

namespace SFA.DAS.FAA.Legacy.Data.Mapper
{
    public static class UserMapper
    {
        public static Domain.Models.User.User ConvertToUser(this MongoUser mongoUser)
        {
            return new Domain.Models.User.User
            {
                Status = mongoUser.Status,
                AccountUnlockCode = mongoUser.AccountUnlockCode,
                AccountUnlockCodeExpiry = mongoUser.AccountUnlockCodeExpiry,
                ActivateCodeExpiry = mongoUser.ActivateCodeExpiry,
                ActivationCode = mongoUser.ActivationCode,
                ActivationDate = mongoUser.ActivationDate,
                DateCreated = mongoUser.DateCreated,
                DateUpdated = mongoUser.DateUpdated,
                EntityId = mongoUser.EntityId,
                LastActivity = mongoUser.LastActivity,
                LastLogin = mongoUser.LastLogin,
                LoginIncorrectAttempts = mongoUser.LoginIncorrectAttempts,
                PasswordResetCode = mongoUser.PasswordResetCode,
                PasswordResetCodeExpiry = mongoUser.PasswordResetCodeExpiry,
                PasswordResetIncorrectAttempts = mongoUser.PasswordResetIncorrectAttempts,
                PendingUsername = mongoUser.PendingUsername,
                PendingUsernameCode = mongoUser.PendingUsernameCode,
                Roles = mongoUser.Roles,
                Username = mongoUser.Username
            };
        }
    }
}
