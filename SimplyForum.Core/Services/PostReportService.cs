using SimplyForum.Core.Contracts;
using SimplyForum.Core.Models.PostReport;
using SimplyForum.Infrastructure.Common;
using SimplyForum.Infrastructure.Data.Models;

namespace SimplyForum.Core.Services
{
    public class PostReportService : IPostReportService
    {

        private readonly IRepository repo;

        public PostReportService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task AddPostReportAsync(AddPostReportModel model)
        {
            PostReport postReport = new PostReport
            {
                Type = model.Type,
                Description = model.Description,
                AuthorId = model.AuthorId,
                PostId = model.PostId
            };

            await repo.AddAsync(postReport);
            await repo.SaveChangesAsync();
        }
    }
}
