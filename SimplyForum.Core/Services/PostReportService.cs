using Microsoft.EntityFrameworkCore;
using SimplyForum.Core.Contracts;
using SimplyForum.Core.Models.PostReport;
using SimplyForum.Infrastructure.Common;
using SimplyForum.Infrastructure.Data.Models;
using SimplyForum.Core.Models.User;

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

        public async Task DeleteAllPostReports(Guid postId)
        {
            var postReports = await repo.All<PostReport>()
                .Where(pr => pr.PostId == postId)
                .ToListAsync();

            if (postReports.Any())
            {
                repo.DeleteRange(postReports);

                await repo.SaveChangesAsync();
            }
        }

        public async Task DeletePostReportAsync(Guid postReportId)
        {
            await repo.DeleteAsync<PostReport>(postReportId);
            await repo.SaveChangesAsync();
        }

        public async Task<ICollection<PostReportModel>> GetAllPostReportsAsync()
        {
            return await repo.AllReadonly<PostReport>()
                .Include(p => p.Author)
                .Select(p => new PostReportModel()
                {
                    Id = p.Id,
                    Type = p.Type,
                    Description = p.Description,
                    User = new UserModel()
                    {
                        UserName = p.Author.UserName,
                        ProfilePicture = p.Author.ProfilePicture
                    },
                    PostId = p.PostId
                })
                .ToListAsync();
        }
    }
}
