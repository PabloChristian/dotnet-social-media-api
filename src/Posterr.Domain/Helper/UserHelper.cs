using Posterr.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posterr.Domain.Helper
{
    public static class UserHelper
    {
        public static void ValidateUser(string? userName)
        {
            if (userName == null)
                throw new UserNotFoundException();
        }

        public static void ValidateUser(Guid? userName)
        {
            if (userName == null)
                throw new UserNotFoundException();
        }
    }
}
