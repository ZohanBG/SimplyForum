using Microsoft.EntityFrameworkCore;
using SimplyForum.Core.Contracts;
using SimplyForum.Core.Services;
using SimplyForum.Infrastructure.Common;
using SimplyForum.Infrastructure.Data;
using SimplyForum.Infrastructure.Data.Models;

namespace SimplyForum.UnitTests
{
    [TestFixture]
    public class ComunityServiceTest
    {
        private IRepository repo;
        private IImageProcessor imageResizer;
        private ICommunityService communityService;
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
        public async Task IsCommunityNameUnique()
        {
            repo = new Repository(applicationDbContext);
            communityService = new CommunityService(repo, imageResizer);

            Assert.IsTrue(await communityService.IsCommunityNameUniqueAsync("Songs"));
            Assert.IsFalse(await communityService.IsCommunityNameUniqueAsync("NotACommunityName"));
        }

        [Test]
        public async Task GetAllCommunities()
        {
            repo = new Repository(applicationDbContext);
            communityService = new CommunityService(repo, imageResizer);

            var communities = await communityService.GetAllCommunitiesAsync();

            Assert.That(communities.Count(), Is.EqualTo(3));

        }

        [Test]
        public async Task GetCommunityDetails()
        {
            repo = new Repository(applicationDbContext);
            communityService = new CommunityService(repo, imageResizer);

            var community = await communityService.GetCommunityDetailsAsync(Guid.ParseExact("89B69807-D8A3-4BEF-92DE-130408B42879", "D"));
            Assert.That(community.Name == "Songs");
        }

        [Test]
        public async Task GetAllUserCommunities()
        {
            repo = new Repository(applicationDbContext);
            communityService = new CommunityService(repo, imageResizer);

            var userCommunity = await communityService.GetAllUserCommunitiesAsync("477194ee-abb3-40c2-9e5b-9c7222ed600f");
            Assert.That(userCommunity.Count(), Is.EqualTo(1));
            Assert.That(userCommunity.Any(uc => uc.Name == "Songs"));
        }

        [Test]
        public async Task GetCommunityIdFromPostId()
        {
            repo = new Repository(applicationDbContext);
            communityService = new CommunityService(repo, imageResizer);

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

            var communityId = await communityService.GetCommunityIdFromPostIdAsync(Guid.ParseExact("89B69807-D8A3-4BEF-92DE-130408B42879", "D"));

            Assert.That(communityId == Guid.ParseExact("89B69807-D8A3-4BEF-92DE-130408B42879", "D"));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
