﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplyForum.Core.Contracts;
using SimplyForum.Core.Models.Community;
using System.Security.Claims;

namespace SimplyForum.Controllers
{
    [Authorize]
    public class CommunityController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly ICommunityService communityService;
        private readonly IPostService postService;
        private readonly ILikeService likeService;

        public CommunityController(ICategoryService _categoryService,
            ICommunityService _communityService,
            IPostService _postservice,
            ILikeService _likeService)
        {
            categoryService = _categoryService;
            communityService = _communityService;
            postService = _postservice;
            likeService = _likeService;
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
                return RedirectToAction(nameof(All));
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
            try
            {
                var model = await communityService.GetCommunityDetailsAsync(communityId);
                model.Posts = await postService.GetAllCommunityPostsAsync(communityId);
                foreach (var post in model.Posts)
                {
                    post.LikeCountModel = await likeService.GetReactionsByPostIdAsync(post.Id);
                }
                return View(model);
            }
            catch 
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> AllUserCommunities()
        {
            string authorId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value!;
            var model = await communityService.GetAllUserCommunitiesAsync(authorId);
            return View(model);
        }
    }
}
