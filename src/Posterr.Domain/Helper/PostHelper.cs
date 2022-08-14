using Posterr.Domain.Exceptions;
using Posterr.Domain.Entity;

namespace Posterr.Domain.Helper
{
    public static class PostHelper
    {
        public const int POSTS_PER_DAY = 5;
        public static void ValidatePostCount(long totalPosts)
        {
            if (totalPosts >= POSTS_PER_DAY)
                throw new LimitPostsExceededException(
                    $"You have exceeded the maximum value of posts \"{POSTS_PER_DAY}\" in one day."
                );
        }

        public static void ValidatePost(Post? post)
        {
            if (post == null || post?.Id == null)
                throw new InvalidPostIdException(
                    $"The Post Id does not exist or is invalid"
                );
        }
    }
}
