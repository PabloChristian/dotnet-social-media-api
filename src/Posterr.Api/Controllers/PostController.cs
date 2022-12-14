using MediatR;
using Microsoft.AspNetCore.Mvc;
using Posterr.Shared.Kernel.Handler;
using Posterr.Shared.Kernel.Notifications;
using Posterr.Application.Post.Commands.CreateQuote;
using Posterr.Application.Posts.Commands.CreateRepost;
using Posterr.Application.Post.Commands.CreatePost;
using Posterr.Application.Post.Queries.GetPostList;
using Posterr.Application.Post.Queries.GetPostByUser;

namespace Posterr.Api.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostController : BaseController
    {
        private const int DEFAULT_POSTS_TAKE_VALUE = 10;

        public PostController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            ILogger<PostController> _)
            : base(notifications, mediator) { }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPosts(
            [FromQuery] DateTime? dateStart,
            [FromQuery] DateTime? dateEnd,
            [FromQuery] int skip = 0,
            [FromQuery] int take = DEFAULT_POSTS_TAKE_VALUE)
        {
            var query = new GetPostListQuery { DateStart = dateStart, DateEnd = dateEnd, Skip = skip, Take = take };
            return Ok(await _mediator.SendCommandResult(query, new CancellationToken()));
        }

        [HttpGet("users/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPostsByUserId(
            [FromQuery] DateTime? dateStart,
            [FromQuery] DateTime? dateEnd,
            [FromRoute] string userId,
            [FromQuery] int skip = 0,
            [FromQuery] int take = DEFAULT_POSTS_TAKE_VALUE)
        {
            var command = new GetPostByUserQuery { DateStart = dateStart, DateEnd = dateEnd, UserName = userId, Skip = skip, Take = take };
            return Ok(await _mediator.SendCommandResult(command, new CancellationToken()));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostCommand command)
            => Ok(await _mediator.SendCommandResult(command, new CancellationToken()));

        [HttpPost("reposts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateRepost([FromBody] CreateRepostCommand command)
            => Ok(await _mediator.SendCommandResult(command, new CancellationToken()));

        [HttpPost("quotes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateQuote([FromBody] CreateQuoteCommand command)
            => Ok(await _mediator.SendCommandResult(command, new CancellationToken()));
    }
}
