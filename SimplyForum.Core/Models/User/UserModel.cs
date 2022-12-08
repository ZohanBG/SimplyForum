namespace SimplyForum.Core.Models.User
{
    public class UserModel
    {
        public string? Id { get; set; }

        public string UserName { get; set; } = null!;

        public byte[] ProfilePicture { get; set; } = null!;
    }
}
