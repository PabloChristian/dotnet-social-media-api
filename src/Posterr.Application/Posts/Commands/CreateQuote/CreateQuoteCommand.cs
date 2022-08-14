using MediatR;
using FluentValidation;
using Posterr.Application.Posts.Commands;
using Posterr.Domain.ViewModel.Post;

namespace Posterr.Application.Post.Commands.CreateQuote
{
    public class CreateQuoteCommand : RepostCommand<CreatePostViewModel>
    {
        public string Quote { get; set; }
        public Guid QuoteId { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new CreateQuoteCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }

        internal class CreateQuoteCommandValidator : AbstractValidator<CreateQuoteCommand>
        {
            public CreateQuoteCommandValidator()
            {
                RuleFor(x => x.Quote)
                    .NotEmpty().WithMessage("The Quote field is required.")
                    .Length(1, 777).WithMessage("The Quote field must be between 1 and 777 characters.");
            }
        }
    }
}
