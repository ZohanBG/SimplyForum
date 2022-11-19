using Microsoft.AspNetCore.Identity;

namespace SimplyForum.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {

        public byte[] ProfilePicture { get; set; } = null!;
    }
}
