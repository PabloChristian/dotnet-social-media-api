using MediatR;
using Microsoft.AspNetCore.Mvc;
using Posterr.Shared.Kernel.Handler;
using Posterr.Shared.Kernel.Notifications;
using Posterr.Application.Posteets.Queries.GetPosteetsByUser;
using Posterr.Application.Post.Commands.CreateQuote;
using Posterr.Application.Posts.Commands.CreateRepost;
using Posterr.Application.Post.Commands.CreatePost;
using Posterr.Application.Posteets.Queries.GetPostList;

namespace Posterr.Api.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostController : BaseController
    {
        private readonly ILogger<PostController> _logger;

        public PostController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            ILogger<PostController> logger)
            : base(notifications, mediator)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPosts(
            [FromQuery] int skip = 0,
            [FromQuery] int take = 10)
        {
            var query = new GetPostListQuery { Skip = skip, Take = take };
            return Ok(await _mediator.SendCommandResult(query, new CancellationToken()));
        }

        [HttpGet("/users/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPostsByUserId(
            [FromRoute] Guid userId,
            [FromQuery] int skip = 0,
            [FromQuery] int take = 5)
        {
            var command = new GetPostByUserQuery { UserName = userId, Skip = skip, Take = take };
            return Ok(await _mediator.SendCommandResult(command, new CancellationToken()));
        }

        /*[HttpGet("DateRange")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PosteetsListDto>> GetByDateRange([FromQuery] GetPostByDataRangeQuery command)
        {
            return Ok(await _mediator.SendCommandResult(command));
        }*/

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostCommand command)
        {
            return Ok(await _mediator.SendCommandResult(command, new CancellationToken()));
        }

        [HttpPost("repost")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateRepost([FromBody] CreateRepostCommand command)
        {
            return Ok(await _mediator.SendCommandResult(command, new CancellationToken()));
        }

        [HttpPost("quote")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateQuote([FromBody] CreateQuoteCommand command)
        {
            return Ok(await _mediator.SendCommandResult(command, new CancellationToken()));
        }
    }
}
