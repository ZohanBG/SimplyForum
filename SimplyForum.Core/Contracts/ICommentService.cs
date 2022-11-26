using SimplyForum.Core.Models.Coment;
using SimplyForum.Core.Models.Post;
using SimplyForum.Infrastructure.Data.Models;

namespace SimplyForum.Core.Contracts
{
    public interface ICommentService
    {
        Task AddCommentAsync(AddCommentModel model, string authorId);

        Task<IEnumerable<Comment>> GetAllPostCommentsAsync(Guid postId);

        Task DeleteComment(Guid commentId); 
    }
}
