using MediatR;
using Microsoft.EntityFrameworkCore;
using Posterr.Application.Post.Commands.CreateQuote;
using Posterr.Domain.Exceptions;
using Posterr.Domain.Interface;
using Posterr.Domain.Interfaces;

namespace Posterr.Application.Posts.Commands.CreateQuote
{
    public class CreateQuoteCommandHandler : IRequestHandler<CreateQuoteCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPostRepository _postRepository;
        private const int POSTS_PER_DAY = 5;

        public CreateQuoteCommandHandler(IUnitOfWork unitOfWork, IPostRepository postRepository)
        {
            _unitOfWork = unitOfWork;
            _postRepository = postRepository;
        }

        public async Task<Guid> Handle(CreateQuoteCommand request, CancellationToken cancellationToken)
        {
            var currentDateValue = DateTime.Today;

            var entity = new Domain.Entity.Post
            {
                UserName = request.UserName,
                RepostId = request.PosteetId,
                PostMessage = request.QuotePost,
            };

            var totalPosts = _postRepository.GetTotalPostsByDateAndUser(entity, currentDateValue, currentDateValue.AddDays(1));

            if (totalPosts >= POSTS_PER_DAY)
                throw new LimitPostsExceededException($"It is not allowed to post more than \"{POSTS_PER_DAY}\" posts in one day. Total posted: ${totalPosts}");

            _postRepository.Add(entity);

            await _unitOfWork.CommitAsync(cancellationToken);

            return entity.Id;
        }
    }
}
