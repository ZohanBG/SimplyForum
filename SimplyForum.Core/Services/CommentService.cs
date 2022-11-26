using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SimplyForum.Core.Contracts;
using SimplyForum.Core.Models.Coment;
using SimplyForum.Core.Models.User;
using SimplyForum.Infrastructure.Common;
using SimplyForum.Infrastructure.Data;
using SimplyForum.Infrastructure.Data.Models;

namespace SimplyForum.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository repo;
        private readonly ApplicationDbContext context;


        public CommentService(IRepository _repo, ApplicationDbContext _context)
        {
            repo = _repo;
            context = _context;
        }

        public async Task AddCommentAsync(AddCommentModel model, string authorId)
        {
            var comment = new Comment()
            {
                Description = model.Description,
                AuthorId = authorId,
                PostId = model.PostId,
                ParentCommentId = model.ParentCommentId
            };

            await repo.AddAsync(comment);
            await repo.SaveChangesAsync();
        }

        public async Task DeleteComment(Guid commentId)
        {
            var comments = await context.Comments
            .Include(x => x.ChildrenComments).ToListAsync();

            var flatten = Flatten(comments.Where(x => x.Id == commentId));

            context.RemoveRange(flatten);

            await context.SaveChangesAsync();
        }

        IEnumerable<Comment> Flatten(IEnumerable<Comment> comments) =>
        comments.SelectMany(x => Flatten(x.ChildrenComments)).Concat(comments);

        public async Task<IEnumerable<Comment>> GetAllPostCommentsAsync(Guid postId)
        {
            List<Comment> comments = await context.Comments
            .AsNoTrackingWithIdentityResolution()
            .Include(c => c.ChildrenComments)
            .Include(c => c.Author)
            .Include(c => c.ParentComment)
            .ToListAsync();

            List<Comment> rootComments = comments
                .Where(c => c.ParentCommentId == null)
            .AsParallel()
            .ToList();
     
            return rootComments;
        }
    }
}
