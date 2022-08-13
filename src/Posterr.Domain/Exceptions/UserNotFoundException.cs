namespace Posterr.Domain.Exceptions
{
    public class UserNotFoundException : DomainException
    {
        public UserNotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) was not found or is invalid") {}
        public UserNotFoundException() : base($"Username was not found or is invalid") { }
    }
}
