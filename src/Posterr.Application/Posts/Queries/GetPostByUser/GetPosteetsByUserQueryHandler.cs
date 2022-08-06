using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Posterr.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Posterr.Application.Posteets.Queries.GetPosteetsByUser
{
    public class GetPosteetsByUserQueryHandler : IRequestHandler<GetPosteetsByUserQuery, PostListDto>
    {
        private readonly IPosterrDbContext _context;
        private readonly IMapper _mapper;

        public GetPosteetsByUserQueryHandler(IPosterrDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PostListDto> Handle(GetPosteetsByUserQuery request, CancellationToken cancellationToken)
        {
            var posteets = await _context.Posteets
                .Where(p => p.UserName == request.UserName)
                .Include(p => p.Reposteet)
                .AsNoTracking()
                .OrderByDescending(e => e.Created)
                .Skip(request.Skip)
                .Take(request.Take)
                .ProjectTo<PostDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new PostListDto
            {
                Posteets = posteets,
                Count = posteets.Count
            };

            return vm;
        }
    }
}