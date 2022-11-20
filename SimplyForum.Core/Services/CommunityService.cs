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
        private readonly IImageResizer imageResizer;

        public CommunityService(IRepository _repo, IImageResizer _imageResizer)
        {
            repo = _repo;
            imageResizer = _imageResizer;   
        }


        public async Task<bool> IsCommunityNameUniqueAsync(string name)
        {
            return await repo.AllReadonly<Community>()
                .FirstOrDefaultAsync(c => c.Name == name) == null ? true : false;
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

    }
}
