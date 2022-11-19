using Microsoft.AspNetCore.Http;
using SimplyForum.Core.Contracts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;

namespace SimplyForum.Core.Services
{
    public class ImageResizer : IImageResizer
    {
        public byte[] ApplicationUserProfileImageResize(IFormFile file)
        {
            using var image = Image.Load(file.OpenReadStream());
            image.Mutate(x => x.Resize(320, 320));
            using var imageStream = new MemoryStream();
            image.Save(imageStream, new PngEncoder());
            var imageBytes = imageStream.ToArray();
            return imageBytes;
        }
    }
}
