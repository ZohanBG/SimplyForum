using Microsoft.EntityFrameworkCore;
using SimplyForum.Core.Contracts;
using SimplyForum.Core.Models.Category;
using SimplyForum.Infrastructure.Common;
using SimplyForum.Infrastructure.Data.Models;
using System.Reflection.Metadata.Ecma335;

namespace SimplyForum.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository repo;

        public CategoryService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task AddCategoryAsync(AddCategoryModel model)
        {
            Category category = new Category()
            {
                Type = model.Type
            };

            await repo.AddAsync(category);
            await repo.SaveChangesAsync();
        }

        public async Task EditCategoryAsync(CategoryModel model)
        {
            var category = await repo.GetByIdAsync<Category>(model.Id);

            category.Type = model.Type;

            await repo.SaveChangesAsync();
        }

        public async Task<List<CategoryModel>> GetAllCategoriesAsync()
        {
            return await repo.AllReadonly<Category>()
                .OrderBy(x => x.Type)
                .Select(c => new CategoryModel()
                {
                    Id = c.Id,
                    Type = c.Type
                })
                .ToListAsync();
        }

        public async Task<CategoryModel> GetCategoryByIdAsync(Guid categoryId)
        {
            var result = await repo.GetByIdAsync<Category>(categoryId);
            return new CategoryModel() { Id = result.Id, Type = result.Type };
        }

        public async Task<bool> IsUniqueAsync(string type)
        {
            return await repo.AllReadonly<Category>().AnyAsync(c => c.Type == type);
        }
    }
}
