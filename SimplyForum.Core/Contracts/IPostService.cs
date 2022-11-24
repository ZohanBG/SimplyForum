using SimplyForum.Core.Models.Post;

namespace SimplyForum.Core.Contracts
{
    public interface IPostService
    {
        Task AddDefaultPostAsync(AddPostModel model);

        Task AddImagePostAsync(AddPostModel model);

        Task AddUrlPostAsync(AddPostModel model);

        Task<IEnumerable<PostModel>> GetAllCommunityPostsAsync(Guid communityId);
    }
}
