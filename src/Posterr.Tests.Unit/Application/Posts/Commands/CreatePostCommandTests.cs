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

namespace Posterr.Tests.Unit.Application.Posts.Commands
{
    public class CreatePostCommandTests : PosterrDbContextFixure
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly Mock<IMediatorHandler> _mockMediator;
        private readonly DomainNotificationHandler _domainNotificationHandler;
        private readonly CreatePostCommandHandler _handler;

        public CreatePostCommandTests()
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

            _userRepository.Add(new User { Id = new Guid(), UserName = "test", UserScreenName = ""});
            _unitOfWork.Commit();

            _handler = new CreatePostCommandHandler(_unitOfWork, _postRepository, _mapper, _userRepository);
        }

        [Fact]
        public async Task Should_CreatePost()
        {
            // Arrange
            var post = new CreatePostCommand() { PostMessage = "test", UserName = "test" };

            // Act
            var result = await _handler.Handle(post, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<CreatePostViewModel>();
            result.PostMessage.Should().Be("test");
            result.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void Should_NotCreatePost_UserInvalid()
        {
            // Arrange
            var post = new CreatePostCommand() { PostMessage = "test", UserName = "test1" };
            var expectedMessage = "Username was not found or is invalid";

            // Act
            var result = _handler.Handle(post, CancellationToken.None);

            // Assert
            var exception = Assert.ThrowsAsync<UserNotFoundException>(() => result);
            exception.Result.Message.Should().Be(expectedMessage);
        }

        [Fact]
        public async Task Should_NotCreatePost_Morethan5PostsOneDay()
        {
            // Arrange
            var post1 = new CreatePostCommand() { PostMessage = "post1", UserName = "test" };
            await _handler.Handle(post1, CancellationToken.None);
            var post2 = new CreatePostCommand() { PostMessage = "post2", UserName = "test" };
            await _handler.Handle(post2, CancellationToken.None);
            var post3 = new CreatePostCommand() { PostMessage = "post3", UserName = "test" };
            await _handler.Handle(post3, CancellationToken.None);
            var post4 = new CreatePostCommand() { PostMessage = "post4", UserName = "test" };
            await _handler.Handle(post4, CancellationToken.None);
            var post5 = new CreatePostCommand() { PostMessage = "post5", UserName = "test" };
            await _handler.Handle(post5, CancellationToken.None);
            await _unitOfWork.CommitAsync(CancellationToken.None);

            var post = new CreatePostCommand() { PostMessage = "test", UserName = "test" };
            var expectedMessage = $"You have exceeded the maximum value of posts (5) in one day.";

            // Act
            var result = _handler.Handle(post, CancellationToken.None);

            // Assert
            var exception = Assert.ThrowsAsync<LimitPostsExceededException>(() => result);
           exception.Result.Message.Should().Be(expectedMessage);
        }
    }
}
