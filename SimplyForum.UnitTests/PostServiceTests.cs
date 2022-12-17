using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using SimplyForum.Core.Contracts;
using SimplyForum.Core.Models.Post;
using SimplyForum.Core.Services;
using SimplyForum.Infrastructure.Common;
using SimplyForum.Infrastructure.Data;
using SimplyForum.Infrastructure.Data.Models;

namespace SimplyForum.UnitTests
{
    [TestFixture]
    public class PostServiceTests
    {
        private IRepository repo;
        private IImageProcessor imageResizer;
        private IPostService postService;
        private ApplicationDbContext applicationDbContext;

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
        public async Task AddDefaultPost()
        {
            repo = new Repository(applicationDbContext);
            postService = new PostService(repo, imageResizer);

            AddPostModel addPost = new AddPostModel
            {
                AuthorId = "477194ee-abb3-40c2-9e5b-9c7222ed600f",
                Title = "NewPost",
                CommunityId = Guid.Parse("89B69807-D8A3-4BEF-92DE-130408B42879"),
                Description = "NewPostDescription"
            };

            await postService.AddDefaultPostAsync(addPost);

            Assert.That(repo.AllReadonly<Post>().Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task AddUrlPost()
        {
            repo = new Repository(applicationDbContext);
            postService = new PostService(repo, imageResizer);

            repo = new Repository(applicationDbContext);
            postService = new PostService(repo, imageResizer);

            AddPostModel addPost = new AddPostModel
            {
                AuthorId = "477194ee-abb3-40c2-9e5b-9c7222ed600f",
                Title = "NewPost",
                CommunityId = Guid.Parse("89B69807-D8A3-4BEF-92DE-130408B42879"),
                Url = "https://www.twitch.tv/thebausffs"
            };

            await postService.AddDefaultPostAsync(addPost);

            Assert.That(repo.AllReadonly<Post>().Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task DeletePost()
        {
            repo = new Repository(applicationDbContext);
            postService = new PostService(repo, imageResizer);

            await repo.AddAsync<Post>(new Post()
            {
                Id = Guid.ParseExact("89B69807-D8A3-4BEF-92DE-130408B42879", "D"),
                Title = "NewPost",
                Description = "NewPostDescription",
                Image = null,
                Url = null,
                CreatedOn = DateTime.Now,
                AuthorId = "477194ee-abb3-40c2-9e5b-9c7222ed600f",
                CommunityId = Guid.ParseExact("89B69807-D8A3-4BEF-92DE-130408B42879", "D")
            });

            await repo.SaveChangesAsync();

            await postService.DeletePostAsync(Guid.ParseExact("89B69807-D8A3-4BEF-92DE-130408B42879", "D"));
            Assert.That(repo.AllReadonly<Post>().Count(), Is.EqualTo(0));
        }

        [Test]
        public async Task GetAllCommunityPosts()
        {
            repo = new Repository(applicationDbContext);
            postService = new PostService(repo, imageResizer);

            Guid communityId = Guid.ParseExact("89B69807-D8A3-4BEF-92DE-130408B42879", "D");

            await repo.AddRangeAsync<Post>(new List<Post>()
            {
                new Post(){
                Id = Guid.ParseExact("89B69807-D8A3-4BEF-92DE-130408B42879", "D"),
                Title = "NewPost1",
                Description = "NewPostDescription1",
                Image = null,
                Url = null,
                CreatedOn = DateTime.Now,
                AuthorId = "477194ee-abb3-40c2-9e5b-9c7222ed600f",
                CommunityId = communityId
            },
            new Post()
            {
                Id = Guid.ParseExact("89B69807-D8A3-4BEF-92DE-130408B42569", "D"),
                Title = "NewPost2",
                Description = "NewPostDescription2",
                Image = null,
                Url = null,
                CreatedOn = DateTime.Now,
                AuthorId = "477194ee-abb3-40c2-9e5b-9c7222ed600f",
                CommunityId = communityId
            }
            }
            );

            await repo.SaveChangesAsync();

            var posts = await postService.GetAllCommunityPostsAsync(Guid.ParseExact("89B69807-D8A3-4BEF-92DE-130408B42879", "D"));

            Assert.That(posts.Count(), Is.EqualTo(2));

        }

        [Test]
        public async Task GetPostAuthor()
        {
            repo = new Repository(applicationDbContext);
            postService = new PostService(repo, imageResizer);

            Guid communityId = Guid.ParseExact("89B69807-D8A3-4BEF-92DE-130408B42879", "D");

            await repo.AddAsync(new Post()
            {
                Id = Guid.ParseExact("89B69807-D8A3-4BEF-92DE-130408B42569", "D"),
                Title = "NewPost2",
                Description = "NewPostDescription2",
                Image = null,
                Url = null,
                CreatedOn = DateTime.Now,
                AuthorId = "477194ee-abb3-40c2-9e5b-9c7222ed600f",
                CommunityId = communityId
            });
            await repo.SaveChangesAsync();

            var authorId = await postService.GetPostAuthorId(Guid.ParseExact("89B69807-D8A3-4BEF-92DE-130408B42569", "D"));

            Assert.That(authorId == "477194ee-abb3-40c2-9e5b-9c7222ed600f");
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
