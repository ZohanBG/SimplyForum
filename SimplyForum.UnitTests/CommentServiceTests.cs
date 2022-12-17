using Microsoft.EntityFrameworkCore;
using SimplyForum.Core.Contracts;
using SimplyForum.Core.Models.Coment;
using SimplyForum.Core.Services;
using SimplyForum.Infrastructure.Common;
using SimplyForum.Infrastructure.Data;
using SimplyForum.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyForum.UnitTests
{
    [TestFixture]
    public class CommentServiceTests
    {
        private IRepository repo;
        private ApplicationDbContext applicationDbContext;
        private ICommentService commentService;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("SimplyForumDB")
            .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }

        [Test]
        public async Task AddComment()
        {
            repo = new Repository(applicationDbContext);
            commentService = new CommentService(repo, applicationDbContext);

            var comment = new AddCommentModel()
            {
                Description = "NewComment",
                PostId = Guid.Empty
            };

            await commentService.AddCommentAsync(comment, "477194ee-abb3-40c2-9e5b-9c7222ed600f");

            Assert.That(repo.AllReadonly<Comment>().Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task DeleteCommentTest()
        {
            repo = new Repository(applicationDbContext);
            commentService = new CommentService(repo, applicationDbContext);

            await repo.AddAsync(new Comment()
            {
                Id = Guid.Parse("672da917-0753-4905-84c2-25da54d69b95"),
                Description = "NewComment",
                PostId = Guid.Empty,
                AuthorId = "77194ee-abb3-40c2-9e5b-9c7222ed600f"
            });

            await repo.SaveChangesAsync();

            await commentService.DeleteComment(Guid.Parse("672da917-0753-4905-84c2-25da54d69b95"));

            Assert.That(repo.AllReadonly<Comment>().Count(), Is.EqualTo(0));
        }

        [Test]
        public async Task GetCommentAuthorIdTest()
        {
            repo = new Repository(applicationDbContext);
            commentService = new CommentService(repo, applicationDbContext);

            await repo.AddAsync(new Comment()
            {
                Id = Guid.Parse("672da917-0753-4905-84c2-25da54d69b95"),
                Description = "NewComment",
                PostId = Guid.Empty,
                AuthorId = "77194ee-abb3-40c2-9e5b-9c7222ed600f"
            });

            await repo.SaveChangesAsync();

            var authorId = await commentService.GetCommentAuthorId(Guid.Parse("672da917-0753-4905-84c2-25da54d69b95"));

            Assert.That(authorId == "77194ee-abb3-40c2-9e5b-9c7222ed600f");
        }


        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
