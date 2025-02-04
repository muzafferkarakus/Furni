using Microsoft.AspNetCore.Mvc;

namespace Furni.WebUI.ViewComponents.Default
{
    public class _DefaultPopularProduct : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
