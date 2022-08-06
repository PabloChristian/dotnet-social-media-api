using System.Collections.Generic;

namespace Posterr.Application.Users.Queries.GetUsersList
{
    public class UsersListDto
    {
        public IList<UserDto> Users { get; set; }

        public int Count { get; set; }
    }
}
