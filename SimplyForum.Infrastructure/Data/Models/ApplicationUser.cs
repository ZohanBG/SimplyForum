using Microsoft.AspNetCore.Identity;

namespace SimplyForum.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public byte[] ProfilePicture { get; set; } = null!;


        public virtual ICollection<Community> Communities { get; set; } = new HashSet<Community>();


        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();
    }
}
