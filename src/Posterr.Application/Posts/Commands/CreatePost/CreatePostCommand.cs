using FluentValidation;
using Posterr.Application.Common;

namespace Posterr.Application.Post.Commands.CreatePost
{
    public class CreatePostCommand<TResult> : GenericCommandResult<TResult>
    {
        public string UserName { get; set; }
        public string Post { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new CreatePostCommandValidator<CreatePostCommand<TResult>>().Validate(this);
            return ValidationResult.IsValid;
        }

        internal class CreatePostCommandValidator<T> : AbstractValidator<T> where T : CreatePostCommand<TResult>
        {
            public CreatePostCommandValidator()
            {
                RuleFor(x => x.UserName)
                    .NotEmpty()
                    .WithMessage("The UserName field is required.");

                RuleFor(x => x.Post)
                    .NotEmpty()
                    .WithMessage("The Post field is required.")
                    .Length(1, 777)
                    .WithMessage("The Post field must be between 1 and 777 characters.");
            }
        }
    }
}
