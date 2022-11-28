using SimplyForum.Infrastructure.Data.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SimplyForum.Infrastructure.Data.Models
{
    public class PostReport
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();


        [Required]
        public ReportType Type { get; set; }


        [Required]
        [StringLength(100)]
        public string Description { get; set; } = null!;


        [Required]
        public string AuthorId { get; set; } = null!;


        [ForeignKey(nameof(AuthorId))]
        public virtual ApplicationUser Author { get; set; } = null!;


        [Required]
        public Guid PostId { get; set; }


        [ForeignKey(nameof(PostId))]
        public virtual Post Post { get; set; } = null!;
    }
}
