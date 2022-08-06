using System.Collections.Generic;

namespace Posterr.Application.Posteets.Queries
{
    public class PostListViewModel
    {
        public IList<PostDto> PostMessages { get; set; }

        public int Count { get; set; }
    }
}
