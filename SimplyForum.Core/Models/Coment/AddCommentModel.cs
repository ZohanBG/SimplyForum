using System.ComponentModel.DataAnnotations;

namespace SimplyForum.Core.Models.Coment
{
    public class AddCommentModel
    {
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Description { get; set; } = null!;


        public Guid PostId { get; set; }


        public Guid? ParentCommentId { get; set; }
    }
}
