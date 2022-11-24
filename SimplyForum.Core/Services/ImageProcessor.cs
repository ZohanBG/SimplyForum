using Microsoft.AspNetCore.Http;
using SimplyForum.Core.Contracts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;

namespace SimplyForum.Core.Services
{
    public class ImageProcessor : IImageProcessor
    {
        public byte[] ApplicationUserProfileImageResize(IFormFile file)
        {
            using var image = Image.Load(file.OpenReadStream());
            image.Mutate(x => x.Resize(256, 256));
            using var imageStream = new MemoryStream();
            image.Save(imageStream, new PngEncoder());
            var imageBytes = imageStream.ToArray();
            return imageBytes;
        }

        public byte[] CommunityBannerImageResize(IFormFile file)
        {
            using var image = Image.Load(file.OpenReadStream());
            image.Mutate(x => x.Resize(1920, 256));
            using var imageStream = new MemoryStream();
            image.Save(imageStream, new PngEncoder());
            var imageBytes = imageStream.ToArray();
            return imageBytes;
        }

        public byte[] CommunityProfileImageResize(IFormFile file)
        {
            using var image = Image.Load(file.OpenReadStream());
            image.Mutate(x => x.Resize(256, 256));
            using var imageStream = new MemoryStream();
            image.Save(imageStream, new PngEncoder());
            var imageBytes = imageStream.ToArray();
            return imageBytes;
        }

        public byte[] PostImageConvert(IFormFile file)
        {
            using var image = Image.Load(file.OpenReadStream());
            using var imageStream = new MemoryStream();
            image.Save(imageStream, new PngEncoder());
            var imageBytes = imageStream.ToArray();
            return imageBytes;
        }
    }
}
