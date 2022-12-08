using Microsoft.EntityFrameworkCore;
using SimplyForum.Core.Contracts;
using SimplyForum.Core.Models.Community;
using SimplyForum.Core.Models.Post;
using SimplyForum.Core.Models.User;
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

        public async Task DeletePostAsync(Guid postId)
        {
            await repo.DeleteAsync<Post>(postId);
            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostModel>> GetAllCommunityPostsAsync(Guid communityId)
        {
            return await repo.AllReadonly<Post>()
                .Include(p => p.Author)
                .Where(p => p.CommunityId == communityId)
                .OrderByDescending(p => p.CreatedOn)
                .Select(p => new PostModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Image = p.Image,
                    Url = p.Url,
                    CreatedOn = p.CreatedOn,
                    User = new UserModel()
                    {
                        Id = p.AuthorId,
                        UserName = p.Author.UserName,
                        ProfilePicture = p.Author.ProfilePicture
                    }
                })
                .ToListAsync();
        }

        public async Task<string> GetPostAuthorId(Guid postId)
        {
            var post = await repo.GetByIdAsync<Post>(postId);
            return post.AuthorId;
        }

        public async Task<PostModel> GetPostDetailsAsync(Guid postId)
        {
            var post = await repo.AllReadonly<Post>()
                .Include(p => p.Author)
                .FirstOrDefaultAsync(p => p.Id == postId);

            if (post != null)
            {
                return new PostModel()
                {
                    Id = post.Id,
                    Title = post.Title,
                    Description = post.Description,
                    Image = post.Image,
                    Url = post.Url,
                    CreatedOn = post.CreatedOn,
                    User = new UserModel()
                    {
                        UserName = post.Author.UserName,
                        ProfilePicture = post.Author.ProfilePicture
                    }
                };
            }

            throw new FileNotFoundException();
        }
    }
}
