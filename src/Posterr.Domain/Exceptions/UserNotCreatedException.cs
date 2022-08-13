namespace Posterr.Domain.Exceptions
{
    public class UserNotCreatedException : DomainException
    {
        public UserNotCreatedException(string message = $"User was not able to be created") : base(message)
        {
        }
    }
}
