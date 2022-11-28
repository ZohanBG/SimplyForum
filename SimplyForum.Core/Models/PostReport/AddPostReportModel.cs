using SimplyForum.Infrastructure.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SimplyForum.Core.Models.PostReport
{
    public class AddPostReportModel
    {
        [Required]
        public ReportType Type { get; set; }


        [Required]
        [StringLength(100,MinimumLength = 3)]
        public string Description { get; set; } = null!;


        public string AuthorId { get; set; } = null!;


        [Required]
        public Guid PostId { get; set; }
    }
}
