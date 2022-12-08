using Microsoft.AspNetCore.Mvc;
using SimplyForum.Core.Contracts;
using SimplyForum.Core.Models.Category;

namespace SimplyForum.Areas.Admin.Controllers
{
    public class ReportController : AdminController
    {
        private readonly IPostReportService postReportService;

        public ReportController(IPostReportService _postReportService)
        {
            postReportService = _postReportService;
        }

        public async Task<IActionResult> All()
        {
            var model = await postReportService.GetAllPostReportsAsync();
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid postReportId)
        {
            await postReportService.DeletePostReportAsync(postReportId);
            return RedirectToAction(nameof(All));
        }
    }
}
