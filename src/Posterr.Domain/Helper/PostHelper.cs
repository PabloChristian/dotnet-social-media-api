using Posterr.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posterr.Domain.Helper
{
    public static class PostHelper
    {
        private const int POSTS_PER_DAY = 5;
        public static void ValidatePostCount(long totalPosts)
        {
            if (totalPosts >= POSTS_PER_DAY)
                throw new LimitPostsExceededException(
                    $"It is not allowed to post more than \"{POSTS_PER_DAY}\" posts in one day. Total posted: ${totalPosts}"
                );
        }
    }
}
