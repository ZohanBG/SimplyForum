using Microsoft.EntityFrameworkCore;
using SimplyForum.Core.Contracts;
using SimplyForum.Core.Models.Community;
using SimplyForum.Infrastructure.Common;
using SimplyForum.Infrastructure.Data.Models;

namespace SimplyForum.Core.Services
{
    public class CommunityService : ICommunityService
    {
        private readonly IRepository repo;
        private readonly IImageProcessor imageResizer;

        public CommunityService(IRepository _repo, IImageProcessor _imageResizer)
        {
            repo = _repo;
            imageResizer = _imageResizer;   
        }


        public async Task<bool> IsCommunityNameUniqueAsync(string name)
        {
            return await repo.AllReadonly<Community>()
                .AnyAsync(c => c.Name == name);
        }


        public async Task AddCommunityAsync(AddCommunityModel model, string authorId)
        {
            var community = new Community
            {
                Name = model.Name,
                CategoryId = model.CategoryId,
                AuthorId = authorId,
                BannerImage = imageResizer.CommunityBannerImageResize(model.BannerImage),
                CommunityImage = imageResizer.CommunityProfileImageResize(model.CommunityImage)
            };

            await repo.AddAsync(community);
            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<CommunityModel>> GetAllCommunitiesAsync()
        {
            return await repo.AllReadonly<Community>()
            .Select(c => new CommunityModel()
            {
                Id = c.Id,
                Name = c.Name,
                CommunityImage = c.CommunityImage,
                CategoryType = c.Category.Type
            })
            .ToListAsync();
        }

        public async Task<CommunityModel> GetCommunityDetailsAsync(Guid communityId)
        {
            var community = await repo.GetByIdAsync<Community>(communityId);
                
            if(community != null)
            {
                return new CommunityModel()
                {
                    Id = community.Id,
                    Name = community.Name,
                    BannerImage = community.BannerImage,
                    CommunityImage = community.CommunityImage,
                };
            }

            throw new FileNotFoundException();
        }

        public async Task<IEnumerable<CommunityModel>> GetAllUserCommunitiesAsync(string userId)
        {
            return await repo.AllReadonly<Community>()
            .Where(c => c.AuthorId == userId)
            .Select(c => new CommunityModel()
            {
                Id = c.Id,
                Name = c.Name,
                CommunityImage = c.CommunityImage,
                CategoryType = c.Category.Type
            })
            .ToListAsync();
        }

        public async Task<Guid?> GetCommunityIdFromPostIdAsync(Guid postId)
        {
            var result = await repo.AllReadonly<Post>().Include(p => p.Community).FirstOrDefaultAsync(p => p.Id == postId);
            return result == null ? null : result.CommunityId;
        }
    }
}
