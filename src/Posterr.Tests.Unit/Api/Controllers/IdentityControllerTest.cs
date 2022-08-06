using Posterr.Domain.CommandHandlers;
using Posterr.Domain.Commands;
using Posterr.Shared.Kernel.Entity;
using Posterr.Shared.Kernel.Handler;
using Posterr.Shared.Kernel.Notifications;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using Xunit;
using FluentAssertions;
using Posterr.Api.Controllers;
using Posterr.Tests.Fixture;
using Microsoft.Extensions.Logging;

namespace Posterr.Tests.Api.Controllers
{
    public class IdentityControllerTest : PosterrChatDbContextFixure
    {
        private readonly Mock<IMediatorHandler> _mockMediator;
        private readonly DomainNotificationHandler _domainNotificationHandler;
        private readonly Mock<ILogger<IdentityController>> _mockLogger;

        public IdentityControllerTest()
        {
            _mockMediator = new Mock<IMediatorHandler>();
            _domainNotificationHandler = new DomainNotificationHandler();
            _mockMediator.Setup(x => x.RaiseEvent(It.IsAny<DomainNotification>())).Callback<DomainNotification>((x) =>
            {
                _domainNotificationHandler.Handle(x, CancellationToken.None);
            });
            _mockLogger = new Mock<ILogger<IdentityController>>();
        }

        [Fact]
        public async Task Should_not_get_authenticated_return_unathourized()
        {
            //Arrange
            var obj = new AuthenticateUserCommand { UserName = "test", Password = "123" };
            _mockMediator.Setup(x => x.SendCommandResult(It.IsAny<GenericCommandResult<bool>>())).Returns(Task.FromResult(false));
            
            //Act
            var result = await new IdentityController(_domainNotificationHandler, _mockMediator.Object, _mockLogger.Object).LoginAsync(obj) as UnauthorizedResult;

            //Assert
            result?.StatusCode.Should().Be((int)HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task Should_get_authenticated_token()
        {
            //Arrange
            string tokenExpected = "asASDNdBNASbdaskjdbabksdavbsklDAPsdh";
            var obj = new AuthenticateUserCommand { UserName = "pablo", Password = "123456" };
            _mockMediator.Setup(x => x.SendCommandResult(It.IsAny<GenericCommandResult<TokenJWT>>())).Returns(Task.FromResult(new TokenJWT
            (
                true,
                "asASDNdBNASbdaskjdbabksdavbsklDAPsdh"
            )));

            //Act
            var result = (await new IdentityController(_domainNotificationHandler, _mockMediator.Object, _mockLogger.Object).LoginAsync(obj) as OkObjectResult)?.Value as ApiOkReturn;
            var token = result?.Data as TokenJWT;

            //Assert
            result?.Success.Should().BeTrue();
            tokenExpected.Should().Be(token?.Token);
        }
    }
}
