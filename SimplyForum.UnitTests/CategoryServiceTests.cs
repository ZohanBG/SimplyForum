using Microsoft.EntityFrameworkCore;
using SimplyForum.Core.Contracts;
using SimplyForum.Core.Models.Category;
using SimplyForum.Core.Services;
using SimplyForum.Infrastructure.Common;
using SimplyForum.Infrastructure.Data;

namespace SimplyForum.UnitTests
{
    [TestFixture]
    public class CategoryServiceTests
    {
        private IRepository repo;
        private ICategoryService categoryService;
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
        public async Task AddCategory()
        {
            repo = new Repository(applicationDbContext);
            categoryService = new CategoryService(repo);

            AddCategoryModel model = new AddCategoryModel()
            {
                Type = "NewType"
            };

            await categoryService.AddCategoryAsync(model);

            var categories = await categoryService.GetAllCategoriesAsync();
            Assert.That(categories.Any(c => c.Type == "NewType"), Is.True);
        }


        [Test]
        public async Task EditCategoryAsync()
        {
            repo = new Repository(applicationDbContext);
            categoryService = new CategoryService(repo);

            var model = await categoryService.GetCategoryByIdAsync(Guid.Parse("F579F2A3-0573-49F0-B0B5-EFA8F52BBBF9"));
            model.Type = "NewFunny";

            await categoryService.EditCategoryAsync(model);

            var newModel = await categoryService.GetCategoryByIdAsync(Guid.Parse("F579F2A3-0573-49F0-B0B5-EFA8F52BBBF9"));

            Assert.That(newModel.Type == "NewFunny");
        }

        [Test]
        public async Task GetAllCategoriesAsync()
        {
            repo = new Repository(applicationDbContext);
            categoryService = new CategoryService(repo);

            var categories = await categoryService.GetAllCategoriesAsync();

            Assert.That(categories.Count() == 4);
            Assert.That(categories.Any(c => c.Type == "Funny"), Is.True);
        }

        [Test]
        public async Task GetCategoryByIdAsync()
        {
            repo = new Repository(applicationDbContext);
            categoryService = new CategoryService(repo);

            var category = await categoryService.GetCategoryByIdAsync(Guid.Parse("F579F2A3-0573-49F0-B0B5-EFA8F52BBBF9"));
            Assert.That(category.Type == "Funny");
        }

        [Test]
        public async Task IsUniqueAsync()
        {
            repo = new Repository(applicationDbContext);
            categoryService = new CategoryService(repo);

            Assert.IsTrue(await categoryService.IsUniqueAsync("Funny"));
            Assert.IsFalse(await categoryService.IsUniqueAsync("NotACategory"));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
