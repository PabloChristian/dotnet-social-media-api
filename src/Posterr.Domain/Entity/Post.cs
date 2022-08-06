using Posterr.Shared.Kernel.Entity;

namespace Posterr.Domain.Entity
{
    public class Post : EntityBase
    {
        public string Message { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
