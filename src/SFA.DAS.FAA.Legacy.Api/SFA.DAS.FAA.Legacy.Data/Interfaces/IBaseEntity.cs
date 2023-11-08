using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SFA.DAS.FAA.Legacy.Data.Interfaces
{
    public interface IBaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        Guid EntityId { get; set; }

        DateTime DateCreated { get; set; }

        DateTime? DateUpdated { get; set; }
    }
}
