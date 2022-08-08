using AutoMapper;
using MediatR;
using Posterr.Domain.Entity;
using Posterr.Domain.Exceptions;
using Posterr.Domain.Interface.Repositories;

namespace Posterr.Application.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var entity = await _userRepository.GetUserData(request.UserName, cancellationToken);

            if (entity == null)
                throw new UserNotFoundException(nameof(User), request.UserName);

            return _mapper.Map<UserDto>(entity);
        }
    }
}
