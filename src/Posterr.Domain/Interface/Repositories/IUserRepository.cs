using Posterr.Domain.Entity;
using Posterr.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Posterr.Domain.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        void Add(Post posts);
        Task AddAsync(Post posts, CancellationToken cancellationToken);
        IEnumerable<Post> GetPosts();
    }
}
