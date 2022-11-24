using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplyForum.Core.Contracts;
using SimplyForum.Core.Models.Community;
using SimplyForum.Core.Models.Post;
using SimplyForum.Core.Services;
using SimplyForum.Infrastructure.Data.Models;
using System.Security.Claims;

namespace SimplyForum.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService _postService)
        {
            postService = _postService;
        }


        [HttpGet]
        public IActionResult Add(Guid id)
        {
            ViewData["PostType"] = "default";
            var model = new AddPostModel()
            {
                CommunityId = id
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddPostModel model)
        {
            model.AuthorId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value!;
            if (model.Description != null)
            {
                if (!ModelState.IsValid)
                {
                    ViewData["PostType"] = "default";
                    return View(nameof(Add), model);
                }
                else
                {
                    await postService.AddDefaultPostAsync(model);
                }
            }
            else if (model.Image != null)
            {
                if (!ModelState.IsValid)
                {
                    ViewData["PostType"] = "image";
                    return View(nameof(Add), model);
                }
                else
                {
                    await postService.AddImagePostAsync(model);
                }
            }
            else if (model.Url != null)
            {
                if (!ModelState.IsValid)
                {
                    ViewData["PostType"] = "url";
                    return View(nameof(Add), model);
                }
                else
                {
                    await postService.AddUrlPostAsync(model);
                }
            }

            return View();
        }

    }
}
