using Posterr.Domain.ViewModel.Post;

namespace Posterr.Domain.Interfaces.Services
{
    public interface IPostService
    {
        List<GetPostViewModel> GetPosts();
        GetPostViewModel GetPostsByUserId(Guid id);
    }
}
