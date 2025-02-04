using Furni.WebUI.Dto.SubscribeDtos;
using Furni.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Furni.WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public DefaultController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = "Modern İç Tasarım Stüdyosu";
            ViewBag.v2 = "Yenlikçi ve modern tasarım ürünlerimizi inceleyebilir detaylar hakkında bilgi sahibi olabilirsiniz, ferah ve konforlu tasarımlarımıza göz atın.";
            return View();
        }

        [HttpGet]
        public PartialViewResult _LayoutFooterSubscribePartial()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> _LayoutFooterSubscribePartial(CreateSubscribeDto createSubscribeDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSubscribeDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseMessage = await client.PostAsync("Subscribe", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
