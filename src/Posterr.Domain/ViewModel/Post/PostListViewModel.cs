using Posterr.Domain.ViewModel.Posts;
using System.Collections.Generic;

namespace Posterr.Domain.ViewModel.Post
{
    public class PostListViewModel
    {
        public IList<PostViewModel> PostMessages { get; set; }

        public int Count { get; set; }
    }
}
