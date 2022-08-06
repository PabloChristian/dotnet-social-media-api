using MediatR;
using FluentValidation;

namespace Posterr.Application.Post.Commands.CreatePost
{
    public class CreatePostCommand : IRequest<int>
    {
        public string UserName { get; set; }
        public string Post { get; set; }
    }
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("The UserName field is required.");
            RuleFor(x => x.Post).NotEmpty().WithMessage("The Post field is required.").Length(1, 777).WithMessage("The Post field must be between 1 and 777 characters.");
        }
    }
}
