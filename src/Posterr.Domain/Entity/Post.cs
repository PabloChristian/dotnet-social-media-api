using Posterr.Shared.Kernel.Entity;
using System.ComponentModel.DataAnnotations;

namespace Posterr.Domain.Entity
{
    public class Post : EntityAudit
    {
        [MaxLength(777)]
        public string PostMessage { get; set; }
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public User User { get; set; }
        public Guid? RepostId { get; set; }
        public virtual Post? Repost { get; set; }
        public ICollection<Post?> Reposts { get; private set; }
    }
}
