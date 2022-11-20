using Microsoft.EntityFrameworkCore;
using SimplyForum.Core.Contracts;
using SimplyForum.Core.Models.Category;
using SimplyForum.Infrastructure.Common;
using SimplyForum.Infrastructure.Data.Models;

namespace SimplyForum.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository repo;

        public CategoryService(IRepository _repo)
        {
            repo = _repo;
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
    }
}
