using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using SimplyForum.Core.Contracts;
using SimplyForum.Core.Models.Category;

namespace SimplyForum.Areas.Admin.Controllers
{
    public class CategoryController : AdminController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddCategoryModel model = new AddCategoryModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryModel model)
        {
            if(model.Type == null || model.Type.Length < 3 || model.Type.Length > 50)
            {
                return View(model);      
            }

            if(await categoryService.IsUniqueAsync(model.Type))
            {
                return View(model);
            }

            await categoryService.AddCategoryAsync(model);
            return RedirectToAction("Index", "Admin", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid categoryId)
        {
            var model = await categoryService.GetCategoryByIdAsync(categoryId);

            if(model.Type == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryModel model)
        {
            if (model.Type == null || model.Type.Length < 3 || model.Type.Length > 50)
            {
                return View(model);
            }

            if (await categoryService.IsUniqueAsync(model.Type))
            {
                return View(model);
            }

            await categoryService.EditCategoryAsync(model);
            return RedirectToAction("Index", "Admin", new { area = "Admin" });
        }

        public async Task<IActionResult> All()
        {
            var model = await categoryService.GetAllCategoriesAsync();

            return View(model);
        }
    }
}
