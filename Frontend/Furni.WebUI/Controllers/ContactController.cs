using Furni.WebUI.Dto.ContactDtos;
using Furni.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Furni.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public ContactController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "İletişim";
            ViewBag.v2 = "24/7 Destek anlayışımızla sizlerin yardımına hazırız. Her türlü soru, sorun ve önerilerinizi dinlemeye hazırız.";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            createContactDto.CreateDate = DateTime.Now;
            createContactDto.Subject = "İletişim Formu";
            var client = _httpClientFactory.CreateClient();
            var JsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseMessage = await client.PostAsync("Contact", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
