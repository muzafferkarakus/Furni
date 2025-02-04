using Furni.WebUI.Dto.SubscribeDtos;
using Furni.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Furni.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminSubscribeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public AdminSubscribeController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v = "/Admin/AdminSubscribe";
            ViewBag.v1 = "Aboneler";
            ViewBag.v2 = "Abone Listesi";
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseMessage = await client.GetAsync("Subscribe");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSubscribeDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
