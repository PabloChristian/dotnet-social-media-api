using MediatR;
using Posterr.Application.Posts.Query;
using Posterr.Domain.ViewModel.Post;

namespace Posterr.Application.Post.Queries.GetPostByUser
{
    public class GetPostByUserQuery : PostQuery<PostListViewModel>
    {
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string UserName { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
