using SimplyForum.Core.Models.User;
using SimplyForum.Infrastructure.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SimplyForum.Core.Models.PostReport
{
    public class PostReportModel
    {
        public ReportType Type { get; set; }


        public string Description { get; set; } = null!;


        public UserModel User { get; set; } = null!;


        public Guid PostId { get; set; }
    }
}
