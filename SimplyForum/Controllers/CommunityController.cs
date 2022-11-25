using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplyForum.Core.Contracts;
using SimplyForum.Core.Models.Community;
using SimplyForum.Core.Services;
using System.Security.Claims;
using System.Xml.Linq;

namespace SimplyForum.Controllers
{
    [Authorize]
    public class CommunityController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly ICommunityService communityService;
        private readonly IPostService postservice;

        public CommunityController(ICategoryService _categoryService,
            ICommunityService _communityService,
            IPostService _postservice)
        {
            categoryService = _categoryService;
            communityService = _communityService;
            postservice = _postservice;
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddCommunityModel()
            {
                CommunityCategories = await categoryService.GetAllCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCommunityModel model)
        {
            if (await communityService.IsCommunityNameUniqueAsync(model.Name))
            {
                ModelState.AddModelError("Name", "Community name is already used!");
                model.CommunityCategories.AddRange(await categoryService.GetAllCategoriesAsync());
                return View(model);
            }

            if (!ModelState.IsValid) {
                model.CommunityCategories.AddRange(await categoryService.GetAllCategoriesAsync());
                return View(model);
            }

            try
            {
                string authorId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value!;

                await communityService.AddCommunityAsync(model, authorId!);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong!");
                model.CommunityCategories.AddRange(await categoryService.GetAllCategoriesAsync());
                return View(model);
            }
        }


        public async Task<IActionResult> All()
        {
            var model = await communityService.GetAllCommunitiesAsync();
            return View(model);
        }

        public async Task<IActionResult> Details(Guid communityId)
        {
            var model = await communityService.GetCommunityDetailsAsync(communityId);
            model.Posts = await postservice.GetAllCommunityPostsAsync(communityId);
            return View(model);
        }

    }
}
