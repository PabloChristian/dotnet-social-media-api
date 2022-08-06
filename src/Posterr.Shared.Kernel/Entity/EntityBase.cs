using System;

namespace Posterr.Shared.Kernel.Entity
{
    public class EntityBase
    {
        public Guid Id { get; set; }
        public EntityBase() => Id = Guid.NewGuid();
    }
}
