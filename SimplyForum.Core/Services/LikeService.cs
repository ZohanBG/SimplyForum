using Microsoft.EntityFrameworkCore;
using SimplyForum.Core.Contracts;
using SimplyForum.Core.Models.Like;
using SimplyForum.Infrastructure.Common;
using SimplyForum.Infrastructure.Data.Models;

namespace SimplyForum.Core.Services
{
    public class LikeService : ILikeService
    {
        private readonly IRepository repo;

        public LikeService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task AddReactionAsync(bool isLike, Guid postId, string userId)
        {
            var reaction = await repo.All<Like>()
                .FirstOrDefaultAsync(l => l.UserId == userId && l.PostId == postId); 

            if(reaction == null)
            {
                Like like = new Like()
                {
                    IsLike = isLike,
                    UserId = userId,
                    PostId = postId
                };

                await repo.AddAsync(like);
            }
            else if (reaction.IsLike == isLike)
            {
                repo.Delete(reaction);
            }
            else
            {
                reaction.IsLike = isLike;
            }

            await repo.SaveChangesAsync();
        }

        public async Task<LikeCountModel> GetReactionsByPostIdAsync(Guid postId)
        {
            var likes = repo.AllReadonly<Like>().Where(r => r.PostId == postId);

            return new LikeCountModel()
            {
                PostId = postId,
                Likes = await likes.CountAsync(r => r.IsLike == true),
                DisLikes = await likes.CountAsync(r => r.IsLike == false)
            };
        }
    }
}
