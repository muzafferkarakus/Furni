using Microsoft.AspNetCore.Mvc;

namespace Furni.WebUI.ViewComponents.Default
{
    public class _DefaultBlogPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
