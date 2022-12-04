using System.ComponentModel.DataAnnotations;

namespace SimplyForum.Core.Models.Category
{
    public class AddCategoryModel
    {
        [Required]
        [StringLength(50,MinimumLength = 3)]
        public string Type { get; set; } = null!;
    }
}
