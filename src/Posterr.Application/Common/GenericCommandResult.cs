using FluentValidation.Results;
using Posterr.Shared.Kernel.Commands;
using Posterr.Shared.Kernel.Handler;
using Posterr.Shared.Kernel.Notifications;

namespace Posterr.Application.Common
{
    public abstract class GenericCommandResult<T> : ICommandResult<T>
    {
        protected GenericCommandResult() => ValidationResult = new ValidationResult();
        protected ValidationResult ValidationResult { get; set; }
        public abstract bool IsValid();
        public virtual IList<ValidationFailure> GetErrors() => ValidationResult.Errors;
        private readonly IMediatorHandler _mediatorHandler;

        public GenericCommandResult(IMediatorHandler mediatorHandler) { _mediatorHandler = mediatorHandler; }

        public async Task SendErrors(CancellationToken cancellationToken)
        {
            foreach (var error in GetErrors())
                await _mediatorHandler.RaiseEvent(new DomainNotification(error.ErrorCode, error.ErrorMessage), cancellationToken);
        }
    }
}
