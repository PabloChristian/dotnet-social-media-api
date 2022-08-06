using MediatR;
using Posterr.Domain.Exceptions;
using Posterr.Domain.Interface;
using Posterr.Domain.Interface.Repositories;

namespace Posterr.Application.Post.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPostRepository _postRepository;
        private const int POSTS_PER_DAY = 5;

        public CreatePostCommandHandler(IUnitOfWork unitOfWork, IPostRepository postRepository)
        {
            _unitOfWork = unitOfWork;
            _postRepository = postRepository;
        }

        public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var currentDateValue = DateTime.Today;

            var entity = new Domain.Entity.Post
            {
                UserName = request.UserName,
                RepostId = request.Id,
            };

            var totalPosts = _postRepository.GetTotalPostsByDateAndUser(entity.UserName, currentDateValue, currentDateValue.AddDays(1));

            if (totalPosts >= POSTS_PER_DAY)
                throw new LimitPostsExceededException($"It is not allowed to post more than \"{POSTS_PER_DAY}\" posts in one day. Total posted: ${totalPosts}");

            _postRepository.Add(entity);

            await _unitOfWork.CommitAsync(cancellationToken);

            return entity.Id;
        }
    }
}
