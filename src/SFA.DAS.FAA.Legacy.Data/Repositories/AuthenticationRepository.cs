using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Polly.Retry;
using Polly;
using SFA.DAS.FAA.Legacy.Domain.Models.User;
using SFA.DAS.FAA.Legacy.Data.Apprenticeships.Entities;
using SFA.DAS.FAA.Legacy.Data.Mapper;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Configuration;

namespace SFA.DAS.FAA.Legacy.Data.Repositories
{
    public class AuthenticationRepository : BaseRepository<MongoUserCredentials>, IAuthenticationRepository
    {
        private readonly ILogger<AuthenticationRepository> _logger;

        public AuthenticationRepository(
            IMongoConfiguration mongoConfiguration,
            ILogger<AuthenticationRepository> logger)
            : base(mongoConfiguration)
        {
            _logger = logger;
        }

        public UserCredentials? Get(Guid id)
        {
            try
            {
                _logger.LogInformation("Called Mongodb to get user credentials with username={id}", id);

                var mongoUser = FilterBy(fil => fil.Id == id);

                return mongoUser.FirstOrDefault()?.ConvertToUserCredentials();
            }
            catch (Exception ex)
            {
                _logger.LogError("Called MongoDb but Un-able to get the user with username={id}", id);
                _logger.LogError("Unable to communicate with MongoDb. Details: {details}", ex.Message);
                throw;
            }
        }
    }
}
