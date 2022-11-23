using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SimplyForum.Infrastructure.Data.Models
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();


        [Required]
        [StringLength(100)]
        public string Title { get; set; } = null!;


        public string? Description { get; set; }


        public byte[]? Image { get; set; }


        public string? Url { get; set; }


        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;


        [Required]
        public string AuthorId { get; set; } = null!;


        [ForeignKey(nameof(AuthorId))]
        public virtual ApplicationUser Author { get; set; } = null!;


        [Required]
        public Guid CommunityId { get; set; }


        [ForeignKey(nameof(CommunityId))]
        public virtual Community Community { get; set; } = null!;
    }
}
