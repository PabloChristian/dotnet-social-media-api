namespace Posterr.Domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) was not found.") {}
    }
}
