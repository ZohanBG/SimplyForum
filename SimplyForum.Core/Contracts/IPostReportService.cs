using SimplyForum.Core.Models.PostReport;

namespace SimplyForum.Core.Contracts
{
    public interface IPostReportService
    {
        Task AddPostReportAsync(AddPostReportModel model);

        Task<ICollection<PostReportModel>> GetAllPostReportsAsync();

        Task DeletePostReportAsync(Guid postReportId);

        Task DeleteAllPostReports(Guid postId);
    }
}
