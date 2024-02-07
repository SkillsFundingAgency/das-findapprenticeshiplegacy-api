namespace SFA.DAS.FAA.Legacy.Data.Apprenticeships.Entities
{
    using MongoDB.Bson.Serialization.Attributes;
    using Concretes;
    using System;

    [BsonCollection("apprenticeships")]
    public class MongoApprenticeships : Domain.Models.Application.Apprenticeship
    {
        [BsonId]
        public Guid Id
        {
            get => EntityId;
            set => EntityId = value;
        }
    }
}
