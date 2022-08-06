using Posterr.Domain.Entity;
using Posterr.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Posterr.Domain.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        void Add(Messages messages);
        Task AddAsync(Messages messages, CancellationToken cancellationToken);
        IEnumerable<Messages> GetMessages();
    }
}
