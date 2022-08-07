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

        public CreateRepostCommandHandler(IUnitOfWork unitOfWork, IPostRepository postRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<CreatePostViewModel> Handle(CreateRepostCommand request, CancellationToken cancellationToken)
        {
            var currentDateValue = DateTime.Today;

            var entity = new Domain.Entity.Post
            {
                UserName = request.UserName,
                RepostId = request.Id,
            };

            var totalPosts = _postRepository.GetTotalPostsByDateAndUser(entity.UserName, currentDateValue, currentDateValue.AddDays(1));

            PostHelper.ValidatePostCount(totalPosts);

            await _postRepository.AddAsync(entity, cancellationToken);

            bool userCreated = await _unitOfWork.CommitAsync(cancellationToken);

            if (!userCreated) throw new UserNotCreatedException();

            return _mapper.Map<CreatePostViewModel>(entity);
        }
    }
}
