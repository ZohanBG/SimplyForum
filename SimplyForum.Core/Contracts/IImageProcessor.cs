using Microsoft.AspNetCore.Http;

namespace SimplyForum.Core.Contracts
{
    public interface IImageProcessor
    {
        byte[] ApplicationUserProfileImageResize(IFormFile file);


        byte[] CommunityProfileImageResize(IFormFile file);


        byte[] CommunityBannerImageResize(IFormFile file);


        byte[] PostImageConvert(IFormFile file);
    }
}
