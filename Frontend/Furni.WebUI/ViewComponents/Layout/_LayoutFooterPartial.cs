using Microsoft.AspNetCore.Mvc;

namespace Furni.WebUI.ViewComponents.Layout
{
    public class _LayoutFooterPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
