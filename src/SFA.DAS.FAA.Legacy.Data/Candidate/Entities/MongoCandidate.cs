namespace SFA.DAS.FAA.Legacy.Data.Candidate.Entities
{
    using MongoDB.Bson.Serialization.Attributes;
    using Concretes;

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