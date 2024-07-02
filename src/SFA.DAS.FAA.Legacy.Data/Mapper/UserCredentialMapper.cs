using SFA.DAS.FAA.Legacy.Data.Apprenticeships.Entities;
using SFA.DAS.FAA.Legacy.Domain.Models.User;

namespace SFA.DAS.FAA.Legacy.Data.Mapper
{
    public static class UserCredentialMapper
    {
        public static UserCredentials ConvertToUserCredentials(this MongoUserCredentials source)
        {
            return new UserCredentials
            {
                EntityId = source.EntityId,
                DateCreated = source.DateCreated,
                DateUpdated = source.DateUpdated,
                PasswordHash = source.PasswordHash
            };
        }
    }
}
