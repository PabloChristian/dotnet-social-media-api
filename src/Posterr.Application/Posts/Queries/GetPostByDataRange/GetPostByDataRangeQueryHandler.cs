using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Posterr.Domain.Interface.Repositories;

namespace Posterr.Application.Posteets.Queries.GetPosteetsByDataRange
{
    public class GetPostByDataRangeQueryHandler : IRequestHandler<GetPostByDataRangeQuery, PostListViewModel>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostByDataRangeQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<PostListViewModel> Handle(GetPostByDataRangeQuery request, CancellationToken cancellationToken)
        {
            var posteets = await _postRepository.GetPostsByDate(request.StartDate,request.EndDate)
                .ProjectTo<PostDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var postListViewModel = new PostListViewModel
            {
                PostMessages = posteets,
                Count = posteets.Count
            };

            return postListViewModel;
        }
    }
}