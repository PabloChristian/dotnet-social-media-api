using MediatR;

namespace Posterr.Application.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public string UserName { get; set; }
    }
}
