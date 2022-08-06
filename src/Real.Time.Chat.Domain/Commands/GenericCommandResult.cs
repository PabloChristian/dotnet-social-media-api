using FluentValidation.Results;
using Posterr.Shared.Kernel.Commands;

namespace Posterr.Domain.Commands
{
    public abstract class GenericCommandResult<T> : ICommandResult<T>
    {
        protected GenericCommandResult() => ValidationResult = new ValidationResult();
        protected ValidationResult ValidationResult { get; set; }
        public abstract bool IsValid();
        public virtual IList<ValidationFailure> GetErrors() => ValidationResult.Errors;
    }
}
