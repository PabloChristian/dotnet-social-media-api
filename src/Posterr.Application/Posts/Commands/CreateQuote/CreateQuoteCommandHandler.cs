using AutoMapper;
using MediatR;
using Posterr.Application.Post.Commands.CreateQuote;
using Posterr.Domain.Exceptions;
using Posterr.Domain.Helper;
using Posterr.Domain.Interface;
using Posterr.Domain.Interface.Repositories;
using Posterr.Domain.ViewModel.Post;

namespace Posterr.Application.Posts.Commands.CreateQuote
{
    public class CreateQuoteCommandHandler : IRequestHandler<CreateQuoteCommand, CreatePostViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateQuoteCommandHandler(IUnitOfWork unitOfWork, IPostRepository postRepository, IMapper mapper, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _postRepository = postRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<CreatePostViewModel> Handle(CreateQuoteCommand request, CancellationToken cancellationToken)
        {
            var currentDateValue = DateTime.Today;

            var userId = await _userRepository.GetUserData(request.UserName, cancellationToken);
            UserHelper.ValidateUser(userId?.Id);

            var totalPosts = _postRepository.GetPosts(currentDateValue, currentDateValue.AddDays(1), request.UserName).Count();
            PostHelper.ValidatePostCount(totalPosts);

            var post = _postRepository.GetPostById(request.QuoteId).FirstOrDefault();
            PostHelper.ValidatePost(post);

            var entity = new Domain.Entity.Post
            {
                UserName = request.UserName,
                UserId = userId.Id,
                RepostId = request.Id,
                PostMessage = request.Quote,
            };

            _postRepository.Add(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _mapper.Map<CreatePostViewModel>(entity);
        }
    }
}
