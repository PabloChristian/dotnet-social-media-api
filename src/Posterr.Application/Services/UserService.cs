using AutoMapper;
using Posterr.Domain.Entity;
using Posterr.Domain.Interfaces;
using Posterr.Domain.Interfaces.Services;
using Posterr.Shared.Kernel.Entity;

namespace Posterr.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public List<Messages> GetMessages() => 
            _userRepository.GetMessages()
                .OrderByDescending(x => x.Date)
                .Take(50)
                .ToList();

        public List<Messages> GetMessages(string username) => 
            _userRepository.GetMessages()
                .Where(x => x.Consumer == username || x.Sender == username)
                .OrderByDescending(x => x.Date)
                .Take(50)
                .ToList();

        public UserDto GetUser(Guid id) => _mapper.Map<UserDto>(_userRepository.GetById(id));
        public List<UserDto> GetUsers() => _mapper.Map<List<UserDto>>(_userRepository.GetAll().ToList());
    }
}
