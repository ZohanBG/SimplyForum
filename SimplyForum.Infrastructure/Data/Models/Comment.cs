using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SimplyForum.Infrastructure.Data.Models
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();


        [Required]
        [StringLength(200)]
        public string Description { get; set; } = null!;


        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;


        [Required]
        public string AuthorId { get; set; } = null!;


        [ForeignKey(nameof(AuthorId))]
        public virtual ApplicationUser Author { get; set; } = null!;


        [Required]
        public Guid PostId { get; set; }


        [ForeignKey(nameof(PostId))]
        public virtual Post Post { get; set; } = null!;


        public Guid? ParentCommentId { get; set; }


        [ForeignKey(nameof(ParentCommentId))]
        public virtual Comment? ParentComment { get; set; }


        public virtual ICollection<Comment> ChildrenComments { get; set; } = new HashSet<Comment>();
    }
}
