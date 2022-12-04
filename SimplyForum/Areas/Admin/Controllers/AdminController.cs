using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static SimplyForum.Areas.Admin.Constraints.AdminConstraints;

namespace SimplyForum.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Route("Admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = AdminRoleName)]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
