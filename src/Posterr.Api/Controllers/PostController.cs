using MediatR;
using Microsoft.AspNetCore.Mvc;
using Posterr.Application.Post.Commands.CreatePost;
using Posterr.Application.Post.Commands.CreateQuote;
using Posterr.Application.Posteets.Commands.CreateReposteet;
using Posterr.Domain.Interfaces.Services;
using Posterr.Domain.ViewModel.Post;
using Posterr.Shared.Kernel.Handler;
using Posterr.Shared.Kernel.Notifications;

namespace Posterr.Api.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostController : BaseController
    {
        private readonly IPostService _postService;
        private readonly ILogger<PostController> _logger;

        public PostController(
            IPostService postService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            ILogger<PostController> logger)
            : base(notifications, mediator)
        {
            _postService = postService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLatestPosts(
            [FromQuery] int skip = 0,
            [FromQuery] int take = 10)
        {
            var command = new GetPostsListQuery { Skip = skip, Take = take };
            return Ok(await _mediator.SendCommandResult(command));
        }

        [HttpGet("/users/{userName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPostsByUserId(
            [FromRoute] Guid userId,
            [FromQuery] int skip = 0,
            [FromQuery] int take = 5)
        {
            var command = new GetPostsByUserQuery { UserName = userId, Skip = skip, Take = take };
            return Ok(await _mediator.SendCommandResult(command));
        }

        /*[HttpGet("DateRange")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PosteetsListDto>> GetByDateRange([FromQuery] GetPostByDataRangeQuery command)
        {
            return Ok(await _mediator.SendCommandResult(command));
        }*/

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostCommand command)
        {
            return Ok(await _mediator.SendCommandResult(command));
        }

        [HttpPost("repost")]
        public async Task<IActionResult> CreateRepost([FromBody] CreateRepostCommand command)
        {
            return Ok(await _mediator.SendCommandResult(command));
        }

        [HttpPost("quote")]
        public async Task<IActionResult> CreateQuote([FromBody] CreateQuoteCommand command)
        {
            return Ok(await _mediator.SendCommandResult(command));
        }
    }
}
