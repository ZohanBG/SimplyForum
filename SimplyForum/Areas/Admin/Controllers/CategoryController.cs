using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
                ModelState.AddModelError(string.Empty, "Type must be atleast 3 letters and shorter that 50");
                return View(model);
                
            }
            await categoryService.AddCategoryAsync(model);
            return RedirectToAction("Index", "Admin", new { area = "Admin" });
        }
    }
}
