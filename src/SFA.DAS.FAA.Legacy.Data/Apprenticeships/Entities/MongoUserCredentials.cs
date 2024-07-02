using MongoDB.Bson.Serialization.Attributes;
using SFA.DAS.FAA.Legacy.Data.Concretes;
using SFA.DAS.FAA.Legacy.Domain.Models.User;

namespace SFA.DAS.FAA.Legacy.Data.Apprenticeships.Entities
{
    [BsonCollection("userCredentials")]
    public class MongoUserCredentials : UserCredentials
    {
        [BsonId]
        public Guid Id
        {
            get { return EntityId; }
            set { EntityId = value; }
        }
    }
}
