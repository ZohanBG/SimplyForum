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
        private readonly ICommentService commentService;
        private readonly ILikeService likeService;
        private readonly IPostReportService postReportService;

        public PostController(IPostService _postService, 
            ICommentService _commentService, 
            ILikeService _likeService,
            IPostReportService _postReportService)
        {
            postService = _postService;
            commentService = _commentService;
            likeService = _likeService;
            postReportService = _postReportService;
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

            return RedirectToAction("Details", "Community", new { communityId = model.CommunityId });
        }


        public async Task<IActionResult> Details(Guid postId)
        {
            ViewBag.userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value!;

            var model = await postService.GetPostDetailsAsync(postId);
            model.LikeCountModel = await likeService.GetReactionsByPostIdAsync(postId);
            model.Comments = await commentService.GetAllPostCommentsAsync(postId);
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid postId, Guid communityId)
        {
            var currentAuthorId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value!;
            var actualAuthorId = await postService.GetPostAuthorId(postId);

            if (actualAuthorId != currentAuthorId && !User.IsInRole("Administrator"))
            {
                return Forbid();
            }

            await likeService.DeleteAllPostReactions(postId);
            await commentService.DeleteAllPostComments(postId);
            await postReportService.DeleteAllPostReports(postId);
            await postService.DeletePostAsync(postId);

            return RedirectToAction("Details", "Community", new { communityId = communityId });
        }
    }
}
