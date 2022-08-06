using MediatR;
using FluentValidation;
using Posterr.Application.Common;

namespace Posterr.Application.Posts.Commands.CreateRepost
{
    public class CreateRepostCommand<TResult> : GenericCommandResult<TResult>
    {
        public string UserName { get; set; }
        public int PosteetId { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new CreateRepostCommandValidator<CreateRepostCommand<TResult>>().Validate(this);
            return ValidationResult.IsValid;
        }

        internal class CreateRepostCommandValidator<T> : AbstractValidator<T> where T : CreateRepostCommand<TResult>
        {
            public CreateRepostCommandValidator()
            {
                RuleFor(x => x.UserName)
                    .NotEmpty()
                    .WithMessage("The UserName field is required.");

                RuleFor(x => x.PosteetId)
                    .GreaterThan(0)
                    .WithMessage("The PosteetId field is required.");
            }
        }
    }
}
