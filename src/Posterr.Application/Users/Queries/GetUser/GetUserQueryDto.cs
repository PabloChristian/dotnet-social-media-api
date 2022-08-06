using MediatR;

namespace Posterr.Application.Users.Queries.GetUser
{
    public class GetUserQueryDto : IRequest<UserDto>
    {
        public string UserName { get; set; }
    }
}
