using Microsoft.AspNetCore.Mvc;

namespace Furni.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v = "/Admin/Dashboard";
            ViewBag.v1 = "Dashboard";
            ViewBag.v2 = "İstatistikler";
            return View();
        }
    }
}
