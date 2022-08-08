using Posterr.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Posterr.Domain.Interface.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        public Task<User> GetUserData(string username, CancellationToken cancellationToken);
        public DbSet<User> GetUsers();
    }
}
