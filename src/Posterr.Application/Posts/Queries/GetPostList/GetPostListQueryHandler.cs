using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Posterr.Domain.Interface.Repositories;
using Posterr.Domain.ViewModel.Post;
using Posterr.Domain.ViewModel.Posts;

namespace Posterr.Application.Post.Queries.GetPostList
{
    public class GetPostListQueryHandler : IRequestHandler<GetPostListQuery, PostListViewModel>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostListQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<PostListViewModel> Handle(GetPostListQuery request, CancellationToken cancellationToken)
        {
            var postsRepo =  _postRepository.GetPosts(request.Skip, request.Take);

            var posts = await postsRepo
                .ProjectTo<PostViewModel>(_mapper.ConfigurationProvider)
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