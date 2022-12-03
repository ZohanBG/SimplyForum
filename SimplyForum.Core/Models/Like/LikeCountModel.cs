namespace SimplyForum.Core.Models.Like
{
    public class LikeCountModel
    {
        public Guid PostId { get; set; }


        public int Likes { get; set; }


        public int DisLikes { get; set; }
    }
}
