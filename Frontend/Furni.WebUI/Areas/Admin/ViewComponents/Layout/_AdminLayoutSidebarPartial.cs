using Microsoft.AspNetCore.Mvc;

namespace Furni.WebUI.Areas.Admin.ViewComponents.Layout
{
    public class _AdminLayoutSidebarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
