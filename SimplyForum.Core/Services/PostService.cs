using SimplyForum.Core.Contracts;
using SimplyForum.Core.Models.Post;
using SimplyForum.Infrastructure.Common;
using SimplyForum.Infrastructure.Data.Models;

namespace SimplyForum.Core.Services
{
    public class PostService : IPostService
    {

        private readonly IRepository repo;
        private readonly IImageProcessor imageResizer;

        public PostService(IRepository _repo, IImageProcessor _imageResizer)
        {
            repo = _repo;
            imageResizer = _imageResizer;
        }

        public async Task AddDefaultPostAsync(AddPostModel model)
        {
            var post = new Post()
            {
                Title = model.Title,
                Description = model.Description,
                AuthorId = model.AuthorId!,
                CommunityId = model.CommunityId
            };

            await repo.AddAsync(post);
            await repo.SaveChangesAsync();
        }

        public async Task AddImagePostAsync(AddPostModel model)
        {
            var post = new Post()
            {
                Title = model.Title,
                Image = imageResizer.PostImageConvert(model!.Image!),
                AuthorId = model.AuthorId!,
                CommunityId = model.CommunityId
            };

            await repo.AddAsync(post);
            await repo.SaveChangesAsync();
        }

        public async Task AddUrlPostAsync(AddPostModel model)
        {
            var post = new Post()
            {
                Title = model.Title,
                Url = model.Url,
                AuthorId = model.AuthorId!,
                CommunityId = model.CommunityId
            };

            await repo.AddAsync(post);
            await repo.SaveChangesAsync();
        }

        public Task<IEnumerable<PostModel>> GetAllCommunityPostsAsync(Guid communityId)
        {
            throw new NotImplementedException();
        }
    }
}
