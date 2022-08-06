using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Posterr.Application.Common.Exceptions;
using Posterr.Application.Common.Interfaces;
using Posterr.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Posterr.Application.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQueryDto, UserDto>
    {
        private readonly IPosterrDbContext _context;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IPosterrDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserQueryDto request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .Include(p => p.Posteets)
                .AsNoTracking()
                .SingleOrDefaultAsync(i => i.UserName == request.UserName);

            if (entity == null)
                throw new NotFoundException(nameof(User), request.UserName);

            return _mapper.Map<UserDto>(entity);
        }
    }
}
