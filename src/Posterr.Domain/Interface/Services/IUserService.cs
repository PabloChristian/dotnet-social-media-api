using Posterr.Domain.Entity;
using Posterr.Domain.ViewModel.User;

namespace Posterr.Domain.Interfaces.Services
{
    public interface IUserService
    {
        List<GetUserViewModel> GetUsers();
        GetUserViewModel GetUser(Guid id);
    }
}
