using Microsoft.AspNetCore.Http;
using SimplyForum.Core.CustomValidationAttributes;
using SimplyForum.Core.Models.Category;
using System.ComponentModel.DataAnnotations;

namespace SimplyForum.Core.Models.Community
{
    public class AddCommunityModel
    {
        [Required]
        [StringLength(50,MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile BannerImage { get; set; } = null!;


        [Required]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile CommunityImage { get; set; } = null!;


        [Required]
        public Guid CategoryId { get; set; }


        public List<CategoryModel> CommunityCategories { get; set; } = new List<CategoryModel>();
    }
}
