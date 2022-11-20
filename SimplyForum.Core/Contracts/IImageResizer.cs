using Microsoft.AspNetCore.Http;

namespace SimplyForum.Core.Contracts
{
    public interface IImageResizer
    {
        byte[] ApplicationUserProfileImageResize(IFormFile file);


        byte[] CommunityProfileImageResize(IFormFile file);


        byte[] CommunityBannerImageResize(IFormFile file);
    }
}
