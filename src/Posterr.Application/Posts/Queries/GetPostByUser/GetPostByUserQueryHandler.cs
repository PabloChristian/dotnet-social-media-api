using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Posterr.Domain.Interface;
using Posterr.Domain.Interfaces;

namespace Posterr.Application.Posteets.Queries.GetPosteetsByUser
{
    public class GetPostByUserQueryHandler : IRequestHandler<GetPostByUserQuery, PostListViewModel>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostByUserQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<PostListViewModel> Handle(GetPostByUserQuery request, CancellationToken cancellationToken)
        {
            var posts = await _postRepository.GetPostsByUser(request.UserName,request.Skip, request.Take)
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