using Posterr.Domain.Entity;

namespace Posterr.Domain.Interface.Repositories
{
    public interface IPostRepository : IRepositoryBase<Post>
    {
        IQueryable<Post> GetPosts(DateTime? dateStart = null, DateTime? dateEnd = null , string user = "", int skip = 0, int take = 10);
        IQueryable<Post> GetPostById(Guid postId);
    }
}
