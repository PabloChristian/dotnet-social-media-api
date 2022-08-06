using Posterr.Shared.Kernel.Entity;
using Posterr.Domain.Entity;

namespace Posterr.Domain.Interfaces.Services
{
    public interface IIdentityService
    {
        User Authenticate(string username, string password);
        TokenJWT GetToken(Guid id, string username);
    }
}
