using Microsoft.EntityFrameworkCore;
using Posterr.Domain.Entity;
using Posterr.Domain.Interface.Repositories;
using Posterr.Infrastructure.Data.Context;

namespace Posterr.Infrastructure.Data.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(PosterrContext context) : base(context) {}

        public IQueryable<Post> GetPosts(DateTime? dateStart = null, DateTime? dateEnd = null, string user = "", int skip = 0, int take = 10)
        {
            var queryAble = _context.Posts.Include(p => p.Repost).AsQueryable().AsNoTracking();

            if (dateStart != null) queryAble = queryAble.Where(x => x.Created >= dateStart);
            if (dateEnd != null) queryAble = queryAble.Where(x => x.Created <= dateEnd);
            if(!string.IsNullOrEmpty(user)) queryAble = queryAble.Where(x => x.UserName.Equals(user));

            return queryAble
                .OrderByDescending(e => e.Created)
                .Skip(skip)
                .Take(take);
        }

        public IQueryable<Post> GetPostById(Guid postId)
        {
            var queryAble = _context.Posts.AsQueryable().AsNoTracking();

            return queryAble
                .Where(x => x.Id.Equals(postId));
        }
    }
}
