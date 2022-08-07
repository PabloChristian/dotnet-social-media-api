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
        private readonly IMapper _mapper;

        public CreateQuoteCommandHandler(IUnitOfWork unitOfWork, IPostRepository postRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<CreatePostViewModel> Handle(CreateQuoteCommand request, CancellationToken cancellationToken)
        {
            var currentDateValue = DateTime.Today;

            var entity = new Domain.Entity.Post
            {
                UserName = request.UserName,
                RepostId = request.Id,
                PostMessage = request.Quote,
            };

            var totalPosts = _postRepository.GetTotalPostsByDateAndUser(entity.UserName, currentDateValue, currentDateValue.AddDays(1));

            PostHelper.ValidatePostCount(totalPosts);

            _postRepository.Add(entity);

            await _unitOfWork.CommitAsync(cancellationToken);

            return _mapper.Map<CreatePostViewModel>(entity);
        }
    }
}
