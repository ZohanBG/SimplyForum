using Microsoft.AspNetCore.Http;
using SimplyForum.Core.CustomValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace SimplyForum.Core.Models.Post
{
    public class AddPostModel
    {
        [StringLength(100, MinimumLength = 10)]
        public string Title { get; set; } = null!;


        [StringLength(500, MinimumLength = 10)]
        public string? Description { get; set; }


        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile? Image { get; set; }


        [Url]
        public string? Url { get; set; }


        public string? AuthorId { get; set; }


        public Guid CommunityId { get; set; }
    }
}
