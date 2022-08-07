using MediatR;
using Posterr.Application.Posts.Query;
using Posterr.Domain.ViewModel.Post;

namespace Posterr.Application.Post.Queries.GetPostList
{
    public class GetPostListQuery : PostQuery<PostListViewModel>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
