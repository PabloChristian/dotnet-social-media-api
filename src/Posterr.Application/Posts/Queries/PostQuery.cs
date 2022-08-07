using FluentValidation;
using Posterr.Application.Common;

namespace Posterr.Application.Posts.Query
{
    public class PostQuery<TResult> : GenericCommandResult<TResult>
    {
        public override bool IsValid()
        {
            ValidationResult = new PostQueryValidator<PostQuery<TResult>>().Validate(this);
            return ValidationResult.IsValid;
        }

        internal class PostQueryValidator<T> : AbstractValidator<T> where T : PostQuery<TResult>
        {
            public PostQueryValidator() {}
        }
    }
}
