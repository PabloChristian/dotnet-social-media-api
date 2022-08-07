using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Posterr.Domain.Interface.Repositories;

namespace Posterr.Application.Posteets.Queries.GetPostList
{
    public class GetPosteetsListQueryHandler : IRequestHandler<GetPostListQuery, PostListViewModel>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPosteetsListQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<PostListViewModel> Handle(GetPostListQuery request, CancellationToken cancellationToken)
        {
            var posts = await _postRepository.GetPosts(request.Skip,request.Take)
                .ProjectTo<PostDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var postsViewModel = new PostListViewModel
            {
                PostMessages = posts,
                Count = posts.Count
            };

            return postsViewModel;
        }
    }
}