using Microsoft.AspNetCore.Mvc;

namespace Furni.WebUI.ViewComponents.Layout
{
    public class _LayoutHeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
