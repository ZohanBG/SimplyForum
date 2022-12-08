using SimplyForum.Core.Models.Category;
using SimplyForum.Infrastructure.Data.Models;

namespace SimplyForum.Core.Contracts
{
    public interface ICategoryService
    {
        Task<List<CategoryModel>> GetAllCategoriesAsync();

        Task<CategoryModel> GetCategoryByIdAsync(Guid categoryId);

        Task AddCategoryAsync(AddCategoryModel model);

        Task EditCategoryAsync(CategoryModel model);

        Task<bool> IsUniqueAsync(string type);
    }
}
