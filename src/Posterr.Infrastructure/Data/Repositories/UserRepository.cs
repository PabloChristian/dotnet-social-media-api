using Posterr.Domain.Entity;
using Posterr.Domain.Interfaces;
using Posterr.Infrastructure.Data.Context;

namespace Posterr.Infrastructure.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(PosterrContext PosterrContext) : base(PosterrContext) {}

        public void Add(Post posts) => Db.Messages.Add(posts);
        public async Task AddAsync(Post posts, CancellationToken cancellationToken) => await Db.Messages.AddAsync(posts, cancellationToken);
        public IEnumerable<Post> GetPosts() => Db.Messages.OrderByDescending(x => x.Date).Take(50);
    }
}
