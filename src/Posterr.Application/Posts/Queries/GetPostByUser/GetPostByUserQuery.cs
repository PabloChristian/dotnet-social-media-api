using MediatR;
using Posterr.Application.Posts.Query;
using Posterr.Domain.ViewModel.Post;

namespace Posterr.Application.Posteets.Queries.GetPosteetsByUser
{
    public class GetPostByUserQuery : PostQuery<PostListViewModel>
    {
        public string UserName { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
