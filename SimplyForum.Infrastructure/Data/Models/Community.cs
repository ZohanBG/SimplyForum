using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SimplyForum.Infrastructure.Data.Models
{
    public class Community
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;


        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;


        [Required]
        public Guid CategoryId { get; set; }


        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; } = null!;


        [Required]
        public string AuthorId { get; set; } = null!;


        [ForeignKey(nameof(AuthorId))]
        public virtual ApplicationUser Author { get; set; } = null!;
    }
}
