using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Posterr.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Posterr.Application.Users.Queries.GetUsersList
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, UsersListDto>
    {
        private readonly IPosterrDbContext _context;
        private readonly IMapper _mapper;

        public GetUsersListQueryHandler(IPosterrDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UsersListDto> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.Users
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new UsersListDto
            {
                Users = users,
                Count = users.Count
            };

            return vm;
        }
    }
}
