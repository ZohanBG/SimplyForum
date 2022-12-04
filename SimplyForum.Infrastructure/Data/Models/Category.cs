using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SimplyForum.Infrastructure.Data.Models
{
    [Index(nameof(Type), IsUnique = true)]
    public class Category
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();


        [Required]
        [StringLength(50)]
        public string Type { get; set; } = null!;


        public virtual ICollection<Community> Communities { get; set; } = new HashSet<Community>();
    }
}
