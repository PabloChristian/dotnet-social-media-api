using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posterr.Application.Users.Queries.GetUsersList
{
    public class UsersListDto
    {
        public IList<UserDto> Users { get; set; }

        public int Count { get; set; }
    }
}
