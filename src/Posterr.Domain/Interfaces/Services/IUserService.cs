using Posterr.Domain.Entity;
using Posterr.Shared.Kernel.Entity;
using System;
using System.Collections.Generic;

namespace Posterr.Domain.Interfaces.Services
{
    public interface IUserService
    {
        List<UserDto> GetUsers();
        UserDto GetUser(Guid id);
        List<Messages> GetMessages();
        List<Messages> GetMessages(string username);
    }
}
