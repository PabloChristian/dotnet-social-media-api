namespace Posterr.Domain.ViewModel.Posts
{
    public class PostViewModel
    {
        public Guid Id { get; set; }
        public string Post { get; set; }
        public string UserName { get; set; }
        public string UserScreeName { get; set; }
        public string UserProfileImageUrl { get; set; }
        public Guid? RepostId { get; set; }
        public string RepostPost { get; set; }
        public string RepostUserName { get; set; }
        public string RepostUserScreenName { get; set; }
        public string RepostUserProfileImageUrl { get; set; }
        public DateTime Created { get; set; }
    }
}
