using Posterr.Domain.Commands.User;
using Posterr.Shared.Kernel.Entity;

namespace Posterr.Domain.CommandHandlers
{
    public class AuthenticateUserCommand : LoginCommand<TokenJWT>
    {
        public override bool IsValid()
        {
            ValidationResult = new AuthenticateUserValidator().Validate(this);
            return ValidationResult.IsValid;
        }

        internal class AuthenticateUserValidator : LoginValidator<AuthenticateUserCommand>
        {
            protected override void StartRules() => base.StartRules();
        }
    }
}
