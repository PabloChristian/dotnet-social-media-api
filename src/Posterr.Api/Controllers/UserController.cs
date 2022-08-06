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

        [HttpGet("{user_id}")]
        public async Task<IActionResult> Get(Guid userId) => Response(await Task.Run(() => _userService.GetUser(userId)));

        [HttpGet("posts")]
        public async Task<IActionResult> GetPosts() => Response(await Task.Run(() => _userService.GetPosts()));
		
		[HttpGet("{user_id}/posts")]
        public async Task<IActionResult> GetPostsById(Guid userId) => Response(await Task.Run(() => _userService.GetPostsById(userId)));
    }
}