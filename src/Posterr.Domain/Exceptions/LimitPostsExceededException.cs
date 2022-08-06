using System.Runtime.Serialization;

namespace Posterr.Domain.Exceptions
{
    public class LimitPostsExceededException : DomainException
    {
        public LimitPostsExceededException(string message) : base(message)
        {
        }
    }
}
