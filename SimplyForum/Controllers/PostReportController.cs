using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplyForum.Core.Contracts;
using SimplyForum.Core.Models.PostReport;
using System.Security.Claims;

namespace SimplyForum.Controllers
{
    [Authorize]
    public class PostReportController : Controller
    {
        private readonly IPostReportService postReportService;

        public PostReportController(IPostReportService _postReportService)
        {
            postReportService = _postReportService;
        }

        [HttpGet]
        public IActionResult Add(Guid id)
        {
            var model = new AddPostReportModel()
            {
                PostId = id
            };

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Add(AddPostReportModel model)
        {
            string authorId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value!;

            model.AuthorId = authorId;

            await postReportService.AddPostReportAsync(model);

            return RedirectToAction("Details", "Post", new { postId = model.PostId });
        }
    }
}
