using Microsoft.AspNetCore.Http;

namespace SimplyForum.Core.Contracts
{
    public interface IImageResizer
    {
        byte[] ApplicationUserProfileImageResize(IFormFile file);
    }
}
