using SFA.DAS.FAA.Legacy.Domain.Concretes;

namespace SFA.DAS.FAA.Legacy.Domain.Models.User
{
    public class UserCredentials : BaseEntity
    {
        public string? PasswordHash { get; set; }
    }
}
