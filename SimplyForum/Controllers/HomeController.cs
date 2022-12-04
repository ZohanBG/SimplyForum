using Microsoft.AspNetCore.Mvc;
using SimplyForum.Models;
using System.Diagnostics;
using static SimplyForum.Areas.Admin.Constraints.AdminConstraints;

namespace SimplyForum.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            if (User.IsInRole(AdminRoleName))
            {
                return RedirectToAction("Index","Admin", new {area = "Admin"});
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}