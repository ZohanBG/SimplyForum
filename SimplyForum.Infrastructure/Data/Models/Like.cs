using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimplyForum.Infrastructure.Data.Models
{
    public class Like
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();


        [Required]
        public string UserId { get; set; } = null!;


        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;


        [Required]
        public Guid PostId { get; set; }


        [ForeignKey(nameof(PostId))]
        public virtual Post Post { get; set; } = null!;


        [Required]
        public bool IsLike { get; set; }
    }
}
