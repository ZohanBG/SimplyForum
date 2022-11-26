using SimplyForum.Core.Models.Coment;
using SimplyForum.Core.Models.User;
using SimplyForum.Infrastructure.Data.Models;

namespace SimplyForum.Core.Models.Post
{
    public class PostModel
    {
        public Guid Id { get; set; }


        public string Title { get; set; } = null!;


        public string? Description { get; set; }


        public byte[]? Image { get; set; }


        public string? Url { get; set; }


        public DateTime CreatedOn { get; set; } = DateTime.Now;


        public UserModel User { get; set; } = null!;


        public IEnumerable<Comment>? Comments { get; set; }
    }
}
