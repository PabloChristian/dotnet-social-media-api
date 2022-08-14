using Posterr.Shared.Kernel.Entity;
using System.ComponentModel.DataAnnotations;

namespace Posterr.Domain.Entity
{
    public class User : EntityBase
    {
        [MaxLength(14)]
        public string UserName { get; set; }
        public string UserScreenName { get; set; }
        public string? ProfileImageUrl { get; set; }
        public DateTime Created { get; set; }
        public ICollection<Post> PostMessage { get; private set; }

        public User() => PostMessage = new HashSet<Post>();
    }
}
