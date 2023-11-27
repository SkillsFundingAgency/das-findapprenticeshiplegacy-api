namespace SFA.DAS.FAA.Legacy.Data.User.Entities
{
    using MongoDB.Bson.Serialization.Attributes;
    using Concretes;
    using System;

    [BsonCollection("users")]
    public class MongoUser : Domain.Models.User.User
    {
        [BsonId]
        public Guid Id
        {
            get => EntityId;
            set => EntityId = value;
        }
    }
}
