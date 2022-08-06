using Posterr.Shared.Kernel.Entity;

namespace Posterr.Domain.Entity
{
    public class User : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
