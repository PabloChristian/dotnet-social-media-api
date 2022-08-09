using Posterr.Shared.Kernel.Entity;

namespace Posterr.Shared.Kernel.Entity
{
    public class EntityAudit : EntityBase
    {
        //public string TimeZone { get; set; }
        public DateTime Created { get; set; }
        //public DateTime? LastModified { get; set; }
    }
}
