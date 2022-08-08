using Microsoft.EntityFrameworkCore;
using Posterr.Domain.Entity;
using Posterr.Domain.Interface.Repositories;
using Posterr.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posterr.Infrastructure.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(PosterrContext context) : base(context) { }

        public async Task<User> GetUserData(string username, CancellationToken cancellationToken)
        {
            return await _context.Users
                    .Include(p => p.PostMessage)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(i => i.UserName.Equals(username), cancellationToken);
        }

        public DbSet<User> GetUsers() => _context.Users;
    }
}
