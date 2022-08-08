using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Posterr.Domain.Entity;
using Posterr.Domain.Exceptions;
using Posterr.Domain.Interface.Repositories;

namespace Posterr.Application.Users.Queries.GetUsersList
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, UsersListDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUsersListQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UsersListDto> Handle(GetUsersListQuery _, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUsers()
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new UsersListDto() { Users = users, Count = users.Count };
        }
    }
}
