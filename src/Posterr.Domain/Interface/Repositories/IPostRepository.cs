using Posterr.Domain.Entity;

namespace Posterr.Domain.Interface.Repositories
{
    public interface IPostRepository : IRepositoryBase<User>
    {
        long GetTotalPostsByDateAndUser(string userName, DateTime dateStart, DateTime dateEnd);
        IQueryable<Post> GetPostsByDate(DateTime? dateStart, DateTime? dateEnd);
        void Add(Post posts);
        Task AddAsync(Post posts, CancellationToken cancellationToken);
        IQueryable<Post> GetPosts(int skip = 0, int take = 10);
        IQueryable<Post> GetPostsByUser(string user, int skip = 0, int take = 10);
    }
}
