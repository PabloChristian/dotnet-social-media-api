namespace Posterr.Application.Posteets.Queries
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Post { get; set; }
        public string UserName { get; set; }
        public string UserScreeName { get; set; }
        public string UserProfileImageUrl { get; set; }
        public int? RepostId { get; set; }
        public string RepostPost { get; set; }
        public string RepostUserName { get; set; }
        public string RepostUserScreenName { get; set; }
        public string RepostUserProfileImageUrl { get; set; }
        public DateTime Created { get; set; }
    }
}
