using MediatR;
using FluentValidation;
using Posterr.Domain.Commands;

namespace Posterr.Application.Post.Commands.CreateQuote
{
    public class CreateQuoteCommand : GenericCommandResult<TResult>
    {
        public string UserName { get; set; }
        public int PosteetId { get; set; }
        public string QuotePost { get; set; }
    }

    public class CreateReposteetQuoteCommandValidator : AbstractValidator<CreateQuoteCommand>
    {
        public CreateReposteetQuoteCommandValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("The UserName field is required.");

            RuleFor(x => x.PosteetId)
                .GreaterThan(0)
                .WithMessage("The PosteetId field is required.");

            RuleFor(x => x.QuotePost)
                .NotEmpty()
                .WithMessage("The Quote Post field is required.")
                .Length(1, 777)
                .WithMessage("The Quote Post field must be between 1 and 777 characters.");
        }
    }
}
