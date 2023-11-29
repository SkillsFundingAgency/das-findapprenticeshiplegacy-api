namespace SFA.DAS.FAA.Legacy.Data.User.Entities
{
    using Domain.Concretes.User;
    using MongoDB.Bson.Serialization.Attributes;
    using SFA.DAS.FAA.Legacy.Data.Concretes;
    using System;

    [BsonCollection("users")]
    public class MongoUser : User
    {
        [BsonId]
        public Guid Id
        {
            get { return EntityId; }
            set { EntityId = value; }
        }
    }
}
