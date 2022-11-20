namespace SimplyForum.Core.Models.Community
{
    public class CommunityModel
    {
        public Guid? Id { get; set; }


        public string? Name { get; set; }


        public byte[]? BannerImage { get; set; }


        public byte[]? CommunityImage { get; set; }


        public DateTime? CreatedOn { get; set; }


        public string? CategoryType { get; set; }


        public string? AuthorId { get; set; }
    }
}
