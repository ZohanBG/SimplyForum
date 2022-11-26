using Microsoft.AspNetCore.Mvc;
using SimplyForum.Core.Contracts;
using SimplyForum.Core.Models.Coment;
using System.Security.Claims;

namespace SimplyForum.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService _commentService)
        {
            commentService = _commentService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCommentModel model)
        {
            if (ModelState.IsValid)
            {
                string authorId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value!;

                await commentService.AddCommentAsync(model, authorId);

            }

            return RedirectToAction("Details", "Post", new { postId = model.PostId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteComment(DeleteCommentModel model)
        {
            await commentService.DeleteComment(model.CommentId);

            return RedirectToAction("Details", "Post", new { postId = model.PostId});
        }

    }
}
