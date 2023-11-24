using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using SFA.DAS.FAA.Legacy.Data.User.Entities;
using SFA.DAS.FAA.Legacy.Domain.Configuration;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories;
using User = SFA.DAS.FAA.Legacy.Domain.Concretes.User.User;


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

        public async Task<Domain.Concretes.User.User> Get(string username)
        {
            _logger.LogInformation($"Called Mongodb to get user with username={username}");

            var mongoUser = FilterBy(
                fil => fil.Username == username.ToLower(),
                Builders<MongoUser>.Sort.Ascending(fil => fil.Status))
                .FirstOrDefault();

            if (mongoUser is null)
            {
                _logger.LogInformation($"Unknown username:{username}");
                return null;
            }
            
            return new Domain.Concretes.User.User();
        }
    }
}
