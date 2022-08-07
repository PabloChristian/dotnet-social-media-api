using FluentValidation;
using Posterr.Application.Posts.Commands;
using Posterr.Domain.ViewModel.Post;

namespace Posterr.Application.Post.Commands.CreatePost
{
    public class CreatePostCommand : PostCommand<CreatePostViewModel>
    {
    }
}
