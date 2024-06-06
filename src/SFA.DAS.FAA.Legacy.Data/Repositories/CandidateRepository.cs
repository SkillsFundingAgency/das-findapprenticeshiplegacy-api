using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using SFA.DAS.FAA.Legacy.Data.Candidate.Entities;
using SFA.DAS.FAA.Legacy.Data.Mapper;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Configuration;
using SFA.DAS.FAA.Legacy.Domain.Interfaces.Repositories;

namespace SFA.DAS.FAA.Legacy.Data.Repositories
{
    public class CandidateRepository : BaseRepository<MongoCandidate>, ICandidateReadRepository
    {
        private readonly ILogger<CandidateRepository> _logger;

        public CandidateRepository(
            IMongoConfiguration mongoConfiguration,
            ILogger<CandidateRepository> logger)
            : base(mongoConfiguration)
        {
            _logger = logger;
        }

        public Domain.Models.Candidate.Candidate? Get(string username)
        {
            try
            {
                _logger.LogInformation("Called Mongodb to get candidate with username={username}", username);

                var mongoCandidate = FilterBy(
                    fil => fil.RegistrationDetails.EmailAddress == username.ToLower());

                return mongoCandidate.FirstOrDefault()?.ConvertToCandidate();
            }
            catch (Exception ex)
            {
                _logger.LogError("Called MongoDb but Un-able to get the candidate with username={username}", username);
                _logger.LogError("Unable to communicate with MongoDb. Details: {details}", ex.Message);
                throw;
            }
        }
    }
}