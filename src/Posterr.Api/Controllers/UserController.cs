using MediatR;
using Microsoft.AspNetCore.Mvc;
using Posterr.Application.Users.Queries.GetUser;
using Posterr.Application.Users.Queries.GetUsersList;
using Posterr.Shared.Kernel.Handler;
using Posterr.Shared.Kernel.Notifications;

namespace Posterr.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : BaseController
    {
        public UserController(
            INotificationHandler<DomainNotification> notifications, 
            IMediatorHandler mediator, 
            ILogger<UserController> _)
            : base(notifications, mediator) { }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetUsersListQuery();
            return Ok(await _mediator.Send(query, new CancellationToken()));
        }

        [HttpGet("{userName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(string userName)
        {
            var query = new GetUserQuery() { UserName = userName };
            return Ok(await _mediator.Send(query, new CancellationToken()));
        }
    }
}
