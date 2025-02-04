using Microsoft.AspNetCore.Mvc;

namespace Furni.WebUI.ViewComponents.Layout
{
    public class _LayoutScriptPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
