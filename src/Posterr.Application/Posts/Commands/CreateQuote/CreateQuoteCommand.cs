using MediatR;
using FluentValidation;
using Posterr.Application.Common;

namespace Posterr.Application.Post.Commands.CreateQuote
{
    public class CreateQuoteCommand<TResult> : GenericCommandResult<TResult>
    {
        public string UserName { get; set; }
        public Guid PostId { get; set; }
        public string Quote { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new CreateQuoteCommandValidator<CreateQuoteCommand<TResult>>().Validate(this);
            return ValidationResult.IsValid;
        }

        internal class CreateQuoteCommandValidator<T> : AbstractValidator<T> where T : CreateQuoteCommand<TResult>
        {
            public CreateQuoteCommandValidator()
            {
                RuleFor(x => x.UserName)
                    .NotEmpty()
                    .WithMessage("The UserName field is required.");

                RuleFor(x => x.PostId)
                    .GreaterThan(0)
                    .WithMessage("The PosteetId field is required.");

                RuleFor(x => x.Quote)
                    .NotEmpty()
                    .WithMessage("The Quote Post field is required.")
                    .Length(1, 777)
                    .WithMessage("The Quote Post field must be between 1 and 777 characters.");
            }
        }
    }
}
