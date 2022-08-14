using Xunit;
using FluentAssertions;
using Posterr.Application.Post.Commands.CreatePost;
using Posterr.Tests.Fixture;
using Posterr.Domain.Interface;
using Moq;
using Posterr.Domain.Interface.Repositories;
using Posterr.Infrastructure.Data;
using Posterr.Infrastructure.Data.Repositories;
using AutoMapper;
using Posterr.Domain.ViewModel.Post;
using Posterr.Domain.Exceptions;
using Posterr.Domain.Entity;
using Posterr.Shared.Kernel.Notifications;
using Posterr.Shared.Kernel.Handler;
using Microsoft.Extensions.Configuration;
using Posterr.Application.AutoMapper;
using Posterr.Application.Post.Queries.GetPostList;

namespace Posterr.Tests.Unit.Application.Posts.Commands
{
    public class GetPostQueryTests : PosterrDbContextFixure
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly Mock<IMediatorHandler> _mockMediator;
        private readonly DomainNotificationHandler _domainNotificationHandler;
        private readonly GetPostListQueryHandler _handler;

        public GetPostQueryTests()
        {
            db = GetDbInstance();
            _unitOfWork = new UnitOfWork(db);
            var mockMapper = AutoMapperConfig.RegisterMappings();
            _mapper = mockMapper.CreateMapper();
            _userRepository = new UserRepository(db);
            _postRepository = new PostRepository(db);

            _mockMediator = new Mock<IMediatorHandler>();
            _domainNotificationHandler = new DomainNotificationHandler();
            _mockMediator.Setup(x => x.RaiseEvent(It.IsAny<DomainNotification>())).Callback<DomainNotification>((x) =>
            {
                _domainNotificationHandler.Handle(x, CancellationToken.None);
            });

            var userGuid = new Guid();
            _userRepository.Add(new User { Id = userGuid, UserName = "test", UserScreenName = ""});
            _postRepository.Add(new Post { Id = new Guid(), UserName = "test", UserId = userGuid, PostMessage = "test" });
            _unitOfWork.Commit();

            _handler = new GetPostListQueryHandler(_postRepository, _mapper);
        }

        [Fact]
        public async Task Should_GetList()
        {
            // Arrange
            var query = new GetPostListQuery() { };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<PostListViewModel>();
        }
    }
}
