using System.Collections.Generic;

namespace Posterr.Application.Posteets.Queries
{
    public class PostListDto
    {
        public IList<PostDto> Posteets { get; set; }

        public int Count { get; set; }
    }
}
