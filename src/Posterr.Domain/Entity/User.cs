using Posterr.Shared.Kernel.Entity;
using System.ComponentModel.DataAnnotations;

namespace Posterr.Domain.Entity
{
    public class User : EntityBase
    {
        [Key]
        [MaxLength(14)]
        public string UserName { get; set; }
        public string UserScreeName { get; set; }
        public string ProfileImageUrl { get; set; }
        public DateTime Joined { get; set; }
        public ICollection<Post> PostMessage { get; private set; }

        public User() => PostMessage = new HashSet<Post>();
    }
}
