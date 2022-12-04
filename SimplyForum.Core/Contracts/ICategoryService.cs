using SimplyForum.Core.Models.Category;
using SimplyForum.Infrastructure.Data.Models;

namespace SimplyForum.Core.Contracts
{
    public interface ICategoryService
    {
        Task<List<CategoryModel>> GetAllCategoriesAsync();

        Task AddCategoryAsync(AddCategoryModel model);
    }
}
