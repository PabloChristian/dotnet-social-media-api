using MediatR;

namespace Posterr.Application.Users.Queries.GetUsersList
{
    public class GetUsersListQuery : IRequest<UsersListDto>
    {
    }
}
