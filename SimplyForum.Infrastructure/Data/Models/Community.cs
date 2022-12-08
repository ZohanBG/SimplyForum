using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SimplyForum.Infrastructure.Data.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Community
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;


        [Required]
        public Guid CategoryId { get; set; }


        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; } = null!;


        [Required]
        public byte[] BannerImage { get; set; } = null!;


        [Required]
        public byte[] CommunityImage { get; set; } = null!;


        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;


        [Required]
        public string AuthorId { get; set; } = null!;


        [ForeignKey(nameof(AuthorId))]
        public virtual ApplicationUser Author { get; set; } = null!;


        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();
    }
}
