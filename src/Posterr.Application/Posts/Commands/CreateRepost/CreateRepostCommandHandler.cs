using AutoMapper;
using MediatR;
using Posterr.Application.Posts.Commands.CreateRepost;
using Posterr.Domain.Exceptions;
using Posterr.Domain.Helper;
using Posterr.Domain.Interface;
using Posterr.Domain.Interface.Repositories;
using Posterr.Domain.ViewModel.Post;

namespace Posterr.Application.Posteets.Commands.CreateReposteet
{
    public class CreateRepostCommandHandler : IRequestHandler<CreateRepostCommand, CreatePostViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public CreateRepostCommandHandler(IUnitOfWork unitOfWork, IPostRepository postRepository, IMapper mapper, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _postRepository = postRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<CreatePostViewModel> Handle(CreateRepostCommand request, CancellationToken cancellationToken)
        {
            var currentDateValue = DateTime.Today;

            var userId = await _userRepository.GetUserData(request.UserName, cancellationToken);
            UserHelper.ValidateUser(userId?.Id);

            var totalPosts = _postRepository.GetPosts(currentDateValue, currentDateValue.AddDays(1), request.UserName).Count();
            PostHelper.ValidatePostCount(totalPosts);

            var post = _postRepository.GetPostById(request.RepostId).FirstOrDefault();
            PostHelper.ValidatePost(post);

            var entity = new Domain.Entity.Post
            {
                UserName = request.UserName,
                UserId = userId.Id,
                RepostId = request.RepostId,
                PostMessage = post.PostMessage
            };

            await _postRepository.AddAsync(entity, cancellationToken);

            bool userCreated = await _unitOfWork.CommitAsync(cancellationToken);

            if (!userCreated) throw new UserNotCreatedException();

            return _mapper.Map<CreatePostViewModel>(entity);
        }
    }
}
