using Posterr.Domain.Interfaces.Services;
using Posterr.Shared.Kernel.Entity;
using Posterr.Shared.Kernel.Handler;
using Posterr.Shared.Kernel.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Posterr.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(
            IUserService userService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            ILogger<UserController> logger)
            : base(notifications, mediator)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Response(await Task.Run(() => _userService.GetUsers()));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) => Response(await Task.Run(() => _userService.GetUser(id)));

        [HttpGet("posts")]
        public async Task<IActionResult> GetPosts() => Response(await Task.Run(() => _userService.GetPosts()));

        [HttpGet("posts/{email}")]
        public async Task<IActionResult> GetPosts(string email)
        {
            var posts = await Task.Run(() => _userService.GetPosts(email));

            if (posts.Any())
            {
                return Response(posts.Select(x => new MessageDto
                {
                    Consumer = x.Consumer,
                    Message = x.Message,
                    Sender = x.Sender,
                    Date = x.Date
                }));
            }

            return Response(posts);
        }
    }
}