using MediatR;
using Posterr.Domain.Exceptions;
using Posterr.Domain.Interface;
using Posterr.Domain.Interface.Repositories;
using Posterr.Shared.Kernel.Handler;
using Posterr.Shared.Kernel.Notifications;
using Posterr.Shared.Kernel.Entity;
using Posterr.Domain.Helper;
using Posterr.Domain.ViewModel.Post;
using AutoMapper;

namespace Posterr.Application.Post.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatePostViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IUnitOfWork unitOfWork, IPostRepository postRepository, IMapper mapper, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _postRepository = postRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<CreatePostViewModel> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) await request.SendErrors(cancellationToken);
            
            var currentDateValue = DateTime.Today;

            var userId = await _userRepository.GetUserData(request.UserName, cancellationToken);
            UserHelper.ValidateUser(userId?.Id);

            var entity = new Domain.Entity.Post
            {
                UserName = request.UserName,
                RepostId = request.Id,
                PostMessage = request.PostMessage,
                UserId = userId?.Id
            };

            var totalPosts = _postRepository.GetTotalPostsByDateAndUser(entity.UserName, currentDateValue, currentDateValue.AddDays(1));

            PostHelper.ValidatePostCount(totalPosts);

            await _postRepository.AddAsync(entity, cancellationToken);

            bool userCreated = await _unitOfWork.CommitAsync(cancellationToken);

            if(!userCreated) throw new UserNotCreatedException();

            return _mapper.Map<CreatePostViewModel>(entity);
        }
    }
}
