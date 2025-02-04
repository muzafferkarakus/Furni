using Microsoft.AspNetCore.Mvc;

namespace Furni.WebUI.Areas.Admin.ViewComponents.Layout
{
    public class _AdminLayoutHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
