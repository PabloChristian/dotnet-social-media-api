using FluentValidation;
using Posterr.Application.Common;

namespace Posterr.Application.Posts.Commands
{
    public class RepostCommand<TResult> : GenericCommandResult<TResult>
    {
        public Guid Id { get; private set; }
        public string UserName { get; set; }

        public RepostCommand() { Id = new Guid(); }

        public override bool IsValid()
        {
            ValidationResult = new RepostValidator<RepostCommand<TResult>>().Validate(this);
            return ValidationResult.IsValid;
        }

        internal class RepostValidator<T> : AbstractValidator<T> where T : RepostCommand<TResult>
        {
            public RepostValidator()
            {
                RuleFor(x => x.UserName)
                    .NotEmpty().WithMessage("The UserName field is required.")
                    .NotNull().WithMessage("The UserName field is required.");
            }
        }
    }
}
