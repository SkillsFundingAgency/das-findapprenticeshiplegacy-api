using SFA.DAS.FAA.Legacy.Data.Interfaces;

namespace SFA.DAS.FAA.Legacy.Data.Concretes
{
    public abstract class BaseEntity : IBaseEntity
    {
        public Guid EntityId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public BaseEntity()
        {
            EntityId = Guid.NewGuid();
            DateCreated = DateTime.UtcNow;
            DateUpdated = new DateTime?(DateCreated);
        }
    }
}
