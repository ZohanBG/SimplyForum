using System.ComponentModel.DataAnnotations;

namespace SimplyForum.Infrastructure.Data.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();


        [Required]
        public string Type { get; set; } = null!;


        public virtual ICollection<Community> Communities { get; set; } = new HashSet<Community>();
    }
}
