using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyForum.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {

        }

        public byte[] ProfilePicture { get; set; } = null!;
    }
}
