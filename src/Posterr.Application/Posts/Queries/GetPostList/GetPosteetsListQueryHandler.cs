using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Posterr.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Posterr.Application.Posteets.Queries.GetPosteetsList
{
    public class GetPosteetsListQueryHandler : IRequestHandler<GetPosteetsListQuery, PostListDto>
    {
        private readonly IPosterrDbContext _context;
        private readonly IMapper _mapper;

        public GetPosteetsListQueryHandler(IPosterrDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PostListDto> Handle(GetPosteetsListQuery request, CancellationToken cancellationToken)
        {
            var posteets = await _context.Posteets
                .Include(p => p.User)
                .Include(p => p.Reposteet)
                    .ThenInclude(r => r.User)
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