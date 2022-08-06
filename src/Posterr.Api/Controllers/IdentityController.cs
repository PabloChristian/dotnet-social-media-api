
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Posterr.Application.SignalR;
using Posterr.Domain.CommandHandlers;
using Posterr.Shared.Kernel.Entity;
using Posterr.Shared.Kernel.Handler;
using Posterr.Shared.Kernel.Notifications;

namespace Posterr.Api.Controllers
{
    [ApiController]
    [Route("api/identity")]
    [AllowAnonymous]
    public class IdentityController : BaseController
    {
        private readonly ILogger<IdentityController> _logger;

        public IdentityController(
            INotificationHandler<DomainNotification> notifications, 
            IMediatorHandler mediator,
            ILogger<IdentityController> logger) 
            : base(notifications, mediator) 
        {
            _logger = logger;
        }

        /// <summary>
        /// Identity control for login
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiOkReturn))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(AuthenticateUserCommand command)
        {
            var token = await _mediator.SendCommandResult(command);

            if (token != null)
            {
                _logger.LogInformation($"{command.UserName} logged in");
                return Response(token);
            }

            return Unauthorized();
        }
    }
}