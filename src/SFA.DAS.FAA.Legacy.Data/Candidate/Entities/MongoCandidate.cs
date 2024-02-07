using MongoDB.Bson.Serialization.Attributes;

namespace SFA.DAS.FAA.Legacy.Data.Candidate.Entities
{
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
