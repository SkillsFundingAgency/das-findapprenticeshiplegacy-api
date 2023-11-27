using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using SFA.DAS.FAA.Legacy.Data.Mapper;
using SFA.DAS.FAA.Legacy.Data.User.Entities;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Configuration;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories;

namespace SFA.DAS.FAA.Legacy.Data.Repositories
{
    public class UserRepository : BaseRepository<MongoUser>, IUserReadRepository
    {
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(
            IMongoConfiguration mongoConfiguration,
            ILogger<UserRepository> logger)
        : base(mongoConfiguration)
        {
            _logger = logger;
        }

        public Domain.Models.User.User? Get(string username)
        {
            try
            {
                _logger.LogInformation($"Called Mongodb to get user with username={username}");

                var mongoUser = FilterBy(
                    fil => fil.Username == username.ToLower(),
                    Builders<MongoUser>.Sort.Ascending(fil => fil.Status));

                return mongoUser.FirstOrDefault()?.ConvertToUser();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Called MongoDb but Un-able to get the user with username={username}");
                _logger.LogError("Unable to communicate with MongoDb. Details: {details}", ex.Message);
                throw;
            }
        }
    }
}
