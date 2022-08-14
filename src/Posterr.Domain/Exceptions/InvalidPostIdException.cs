using System.Runtime.Serialization;

namespace Posterr.Domain.Exceptions
{
    public class InvalidPostIdException : DomainException
    {
        public InvalidPostIdException(string message) : base(message) {}
    }
}
