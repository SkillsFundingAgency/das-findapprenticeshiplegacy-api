using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using SFA.DAS.FAA.Legacy.Data.Candidate.Entities;
using SFA.DAS.FAA.Legacy.Data.Mapper;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Configuration;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories;

namespace SFA.DAS.FAA.Legacy.Data.Repositories
{
    public class CandidateReadRepository : BaseRepository<MongoCandidate>, ICandidateReadRepository
    {
        private readonly ILogger<CandidateReadRepository> _logger;

        public CandidateReadRepository(
            IMongoConfiguration mongoConfiguration,
            ILogger<CandidateReadRepository> logger)
            : base(mongoConfiguration)
        {
            _logger = logger;
        }

        public Domain.Models.Candidate.Candidate? Get(Guid id)
        {
            try
            {
                _logger.LogInformation("Called Mongodb to get candidate with id={id}", id);

                var mongoCandidate = FilterBy(
                    fil => fil.Id == id);

                return mongoCandidate.FirstOrDefault()?.ConvertToCandidate();
            }
            catch (Exception ex)
            {
                _logger.LogError("Called MongoDb but Un-able to get the candidate with id={id}", id);
                _logger.LogError("Unable to communicate with MongoDb. Details: {details}", ex.Message);
                throw;
            }
        }
    }
}
