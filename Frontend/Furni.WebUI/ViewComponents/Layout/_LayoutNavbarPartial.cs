using Microsoft.AspNetCore.Mvc;

namespace Furni.WebUI.ViewComponents.Layout
{
    public class _LayoutNavbarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
