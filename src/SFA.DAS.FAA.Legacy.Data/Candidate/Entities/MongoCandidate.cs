using MongoDB.Bson.Serialization.Attributes;
using SFA.DAS.FAA.Legacy.Data.Concretes;

namespace SFA.DAS.FAA.Legacy.Data.Candidate.Entities
{
    [BsonCollection("candidates")]
    public class MongoCandidate : Domain.Models.Candidate.Candidate
    {
        [BsonId]
        public Guid Id
        {
            get => EntityId;
            set => EntityId = value;
        }
    }
}
