namespace SimplyForum.Core.Models.Coment
{
    public class DeleteCommentModel
    {
        public Guid PostId { get; set; }

        public Guid CommentId { get; set; }
    }
}
