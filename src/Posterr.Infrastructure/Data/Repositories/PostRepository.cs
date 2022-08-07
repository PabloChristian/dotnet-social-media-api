using Microsoft.EntityFrameworkCore;
using Posterr.Domain.Entity;
using Posterr.Domain.Interface.Repositories;
using Posterr.Infrastructure.Data.Context;

namespace Posterr.Infrastructure.Data.Repositories
{
    public class PostRepository : RepositoryBase<User>, IPostRepository
    {
        public PostRepository(PosterrContext context) : base(context) {}

        public long GetTotalPostsByDateAndUser(string userName, DateTime dateStart, DateTime dateEnd)
        {
            return _context.Posts
                .Where(p => p.UserName == userName && p.Created >= dateStart && p.Created < dateEnd)
                .AsNoTracking().Count();
        }

        public IQueryable<Post> GetPostsByDate(DateTime? dateStart, DateTime? dateEnd)
        {
            return _context.Posts
                .Where(p => (dateStart == null || p.Created >= dateStart) && (dateEnd == null || p.Created < dateEnd))
                .Include(p => p.Repost)
                .AsNoTracking()
                .OrderByDescending(e => e.Created);
        }

        public IQueryable<Post> GetPosts(int skip = 0, int take = 10)
        {
            return _context.Posts
                .Include(p => p.Repost)
                .AsNoTracking()
                .OrderByDescending(e => e.Created)
                .Skip(skip)
                .Take(take);
        }

        public IQueryable<Post> GetPostsByUser(string user, int skip = 0, int take = 10)
        {
            return _context.Posts
                .Where(p => p.UserName.Equals(user))
                .Include(p => p.Repost)
                .AsNoTracking()
                .OrderByDescending(e => e.Created)
                .Skip(skip)
                .Take(take);
        }

        public void Add(Post posts) => _context.Posts.Add(posts);
        public async Task AddAsync(Post posts, CancellationToken cancellationToken) => await _context.Posts.AddAsync(posts, cancellationToken);
    }
}
