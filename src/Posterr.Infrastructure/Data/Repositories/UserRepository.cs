using Posterr.Domain.Entity;
using Posterr.Domain.Interfaces;
using Posterr.Infrastructure.Data.Context;

namespace Posterr.Infrastructure.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(PosterrChatContext posterrChatContext) : base(posterrChatContext) {}

        public void Add(Messages messages) => Db.Messages.Add(messages);
        public async Task AddAsync(Messages messages, CancellationToken cancellationToken) => await Db.Messages.AddAsync(messages, cancellationToken);
        public IEnumerable<Messages> GetMessages() => Db.Messages.OrderByDescending(x => x.Date).Take(50);
    }
}
