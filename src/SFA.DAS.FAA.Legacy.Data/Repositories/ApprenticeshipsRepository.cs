using Microsoft.Extensions.Logging;
using SFA.DAS.FAA.Legacy.Data.Apprenticeships.Entities;
using SFA.DAS.FAA.Legacy.Data.Mapper;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Configuration;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories;

namespace SFA.DAS.FAA.Legacy.Data.Repositories
{
    public class ApprenticeshipsRepository : BaseRepository<MongoApprenticeships>, IApprenticeshipsReadRepository
    {
        private readonly ILogger<ApprenticeshipsRepository> _logger;

        public ApprenticeshipsRepository(
            IMongoConfiguration mongoConfiguration,
            ILogger<ApprenticeshipsRepository> logger) 
            : base(mongoConfiguration)
        {
            _logger = logger;
        }

        public IEnumerable<Domain.Models.Application.Apprenticeships> Get(string username)
        {
            try
            {
                _logger.LogInformation("Called Mongodb to get apprenticeship for username={username}", username);

                var mongoApprenticeships = FilterBy(fil => fil.CandidateDetails.EmailAddress == username.ToLower()).ToList();

                return mongoApprenticeships.Select(apprenticeship => apprenticeship.ConvertToApprenticeship()).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Called MongoDb but Un-able to get apprenticeship for with username={username}", username);
                _logger.LogError("Unable to communicate with MongoDb. Details: {details}", ex.Message);
                throw;
            }
        }
    }
}
