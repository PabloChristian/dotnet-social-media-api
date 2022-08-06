using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Posterr.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Posterr.Application.Posteets.Queries.GetPosteetsByDataRange
{
    public class GetPosteetsByDataRangeQueryHandler : IRequestHandler<GetPosteetsByDataRangeQuery, PostListDto>
    {
        private readonly IPosterrDbContext _context;
        private readonly IMapper _mapper;

        public GetPosteetsByDataRangeQueryHandler(IPosterrDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PostListDto> Handle(GetPosteetsByDataRangeQuery request, CancellationToken cancellationToken)
        {
            var posteets = await _context.Posteets
                .Where(p => (request.StartDate == null || p.Created >= request.StartDate) && (request.EndDate == null || p.Created < request.EndDate))
                .Include(p => p.Reposteet)
                .AsNoTracking()
                .OrderByDescending(e => e.Created)
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