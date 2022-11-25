using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyForum.Core.Models.User
{
    public class UserModel
    {
        public string UserName { get; set; } = null!;

        public byte[] ProfilePicture { get; set; } = null!;
    }
}
