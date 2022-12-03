using SimplyForum.Core.Models.Like;

namespace SimplyForum.Core.Contracts
{
    public interface ILikeService
    {
        Task AddReactionAsync(bool isLike, Guid postId, string userId); 

        Task<LikeCountModel> GetReactionsByPostIdAsync(Guid postId);
    }
}
