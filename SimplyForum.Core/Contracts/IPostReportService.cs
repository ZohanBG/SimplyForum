using SimplyForum.Core.Models.PostReport;

namespace SimplyForum.Core.Contracts
{
    public interface IPostReportService
    {
        Task AddPostReportAsync(AddPostReportModel model);
    }
}
