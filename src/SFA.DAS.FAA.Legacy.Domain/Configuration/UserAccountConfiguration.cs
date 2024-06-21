using SFA.DAS.FAA.Legacy.Domain.Interfaces.Configuration;

namespace SFA.DAS.FAA.Legacy.Domain.Configuration
{
    public class UserAccountConfiguration : IUserAccountConfiguration
    {
        public string UserDirectorySecretKey { get; set; }
    }
}