using Furni.WebUI.Dto.StaffDtos;
using Furni.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Furni.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminStaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public AdminStaffController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v = "/Admin/AdminStaff";
            ViewBag.v1 = "Ekipler";
            ViewBag.v2 = "Ekip Listesi";
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseMessage = await client.GetAsync("Staff");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultStaffDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateStaff()
        {
            ViewBag.v = "/Admin/AdminStaff";
            ViewBag.v1 = "Ekipler";
            ViewBag.v2 = "Ekip Ekleme";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStaff(CreateStaffDto createStaffDto, IFormFile file)
        {
            var client = _httpClientFactory.CreateClient();
            if (createStaffDto.file != null && createStaffDto.file.Length > 0)
            {
                var fileName = Path.GetFileName(createStaffDto.file.FileName);
                var filePath = Path.Combine("wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await createStaffDto.file.CopyToAsync(stream);
                }
                createStaffDto.ImageUrl = $"/images/{fileName}";
                var jsonData = JsonConvert.SerializeObject(createStaffDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri(_apiSettings.BaseUrl);
                var responseMessage = await client.PostAsync("Staff", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "AdminStaff");
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            ViewBag.v = "/Admin/AdminStaff";
            ViewBag.v1 = "Ekipler";
            ViewBag.v2 = "Ekip Güncelleme";
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseMessage = await client.GetAsync("Staff/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateStaffDto>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseMessage = await client.DeleteAsync("Staff/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminStaff");
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffDto updateStaffDto, IFormFile file)
        {
            var client = _httpClientFactory.CreateClient();
            if (updateStaffDto.file != null && updateStaffDto.file.Length > 0)
            {
                var fileName = Path.GetFileName(updateStaffDto.file.FileName);
                var filePath = Path.Combine("wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await updateStaffDto.file.CopyToAsync(stream);
                }
                updateStaffDto.ImageUrl = $"/images/{fileName}";
                var jsonData = JsonConvert.SerializeObject(updateStaffDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri(_apiSettings.BaseUrl);
                var responseMessage = await client.PutAsync("Staff", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "AdminStaff");
                }
            }
            return View();
        }
    }
}
