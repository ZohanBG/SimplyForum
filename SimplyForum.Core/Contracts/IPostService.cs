using SimplyForum.Core.Models.Post;

namespace SimplyForum.Core.Contracts
{
    public interface IPostService
    {
        Task AddDefaultPostAsync(AddPostModel model);

        Task AddImagePostAsync(AddPostModel model);

        Task AddUrlPostAsync(AddPostModel model);

        Task<IEnumerable<PostModel>> GetAllCommunityPostsAsync(Guid communityId);

        Task<PostModel> GetPostDetailsAsync(Guid postId);

        Task<string> GetPostAuthorId(Guid postId);

        Task DeletePostAsync(Guid postId);
    }
}
