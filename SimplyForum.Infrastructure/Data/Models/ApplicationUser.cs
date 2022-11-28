using Microsoft.AspNetCore.Identity;

namespace SimplyForum.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public byte[] ProfilePicture { get; set; } = null!;


        public virtual ICollection<Community> Communities { get; set; } = new HashSet<Community>();


        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();


        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();


        public virtual ICollection<PostReport> PostsReports { get; set; } = new HashSet<PostReport>();


        public virtual ICollection<Like> Likes { get; set; } = new HashSet<Like>();
    }
}
