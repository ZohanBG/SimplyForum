using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplyForum.Core.Contracts;
using System.Security.Claims;

namespace SimplyForum.Controllers
{
    [Authorize]
    public class ReactionController : Controller
    {
        private readonly ILikeService likeService;

        public ReactionController(ILikeService _likeService)
        {
            likeService = _likeService;
        }

        public async Task<IActionResult> Like(Guid postId, string returnUrl)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value!;

            await likeService.AddReactionAsync(true, postId, userId);

            return Redirect(returnUrl);
        }

        public async Task<IActionResult> DisLike(Guid postId, string returnUrl)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value!;

            await likeService.AddReactionAsync(false, postId, userId);

            return Redirect(returnUrl);
        }
    }
}
