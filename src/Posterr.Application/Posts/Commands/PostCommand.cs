using FluentValidation;
using Posterr.Application.Common;

namespace Posterr.Application.Posts.Commands
{
    public class PostCommand<TResult> : GenericCommandResult<TResult>
    {
        public Guid Id { get; private set; }
        public string UserName { get; set; }
        public string PostMessage { get; set; }

        public PostCommand() { Id = new Guid(); }

        public override bool IsValid()
        {
            ValidationResult = new PostValidator<PostCommand<TResult>>().Validate(this);
            return ValidationResult.IsValid;
        }

        internal class PostValidator<T> : AbstractValidator<T> where T : PostCommand<TResult>
        {
            public PostValidator()
            {
                RuleFor(x => x.UserName)
                    .NotEmpty().WithMessage("The UserName field is required.")
                    .NotNull().WithMessage("The UserName field is required.");

                RuleFor(x => x.PostMessage)
                    .NotEmpty().WithMessage("The Post field is required.")
                    .Length(1, 777).WithMessage("The Post field must be between 1 and 777 characters.");
            }
        }
    }
}
