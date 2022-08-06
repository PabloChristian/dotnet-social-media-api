using MediatR;

namespace Posterr.Application.Posteets.Queries.GetPosteetsByUser
{
    public class GetPosteetsByUserQuery : IRequest<PostListDto>
    {
        public string UserName { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
