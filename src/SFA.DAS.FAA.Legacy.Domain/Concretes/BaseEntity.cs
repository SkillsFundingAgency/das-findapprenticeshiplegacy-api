using SFA.DAS.FAA.Legacy.Domain.Interfaces.Entities;

namespace SFA.DAS.FAA.Legacy.Domain.Concretes
{
    public abstract class BaseEntity : IBaseEntity
    {
        public Guid EntityId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        protected BaseEntity()
        {
            DateCreated = DateTime.UtcNow;
            DateUpdated = new DateTime?(DateCreated);
        }
    }
}
