using Microsoft.AspNetCore.Mvc;

namespace Furni.WebUI.ViewComponents.Layout
{
    public class _LayoutHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
