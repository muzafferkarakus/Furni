using Furni.WebUI.Dto.TestimonialDtos;
using Furni.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Furni.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminTestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public AdminTestimonialController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v = "/Admin/AdminTestimonial";
            ViewBag.v1 = "Referanslar";
            ViewBag.v2 = "Referans Listesi";
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseMessage = await client.GetAsync("Testimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateTestimonial()
        {
            ViewBag.v = "/Admin/AdminTestimonial";
            ViewBag.v1 = "Referanslar";
            ViewBag.v2 = "Referans Ekleme";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            if (createTestimonialDto.file != null && createTestimonialDto.file.Length > 0)
            {
                var fileName = Path.GetFileName(createTestimonialDto.file.FileName);
                var filePath = Path.Combine("wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await createTestimonialDto.file.CopyToAsync(stream);
                }
                createTestimonialDto.ImageUrl = $"/images/{fileName}";
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createTestimonialDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri(_apiSettings.BaseUrl);
                var responseMessage = await client.PostAsync("Testimonial", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                }
                return View();
            }

            [HttpGet]
            public async Task<IActionResult> UpdateTestimonial(int id, IFormFile file)
            {
                ViewBag.v = "/Admin/AdminTestimonial";
                ViewBag.v1 = "Referanslar";
                ViewBag.v2 = "Referans Güncelleme";
                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_apiSettings.BaseUrl);
                var responseMessage = await client.GetAsync("Testimonial/" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<UpdateTestimonialDto>(jsonData);
                    return View(values);
                }
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
            {
                var client = _httpClientFactory.CreateClient();
            if (updateTestimonialDto.file != null && updateTestimonialDto.file.Length > 0)
            {
                var fileName = Path.GetFileName(updateTestimonialDto.file.FileName);
                var filePath = Path.Combine("wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await updateTestimonialDto.file.CopyToAsync(stream);
                }
                updateTestimonialDto.ImageUrl = $"/images/{fileName}";
                var jsonData = JsonConvert.SerializeObject(updateTestimonialDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri(_apiSettings.BaseUrl);
                var responseMessage = await client.PutAsync("Testimonial", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                }
                return View();
            }
        }
    }
