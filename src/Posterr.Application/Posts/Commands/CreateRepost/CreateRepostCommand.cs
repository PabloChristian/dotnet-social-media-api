using Posterr.Domain.ViewModel.Post;

namespace Posterr.Application.Posts.Commands.CreateRepost
{
    public class CreateRepostCommand : RepostCommand<CreatePostViewModel>
    {
        public Guid RepostId { get; set; }
    }
}
