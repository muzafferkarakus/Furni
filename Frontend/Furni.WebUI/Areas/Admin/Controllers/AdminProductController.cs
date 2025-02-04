using Furni.WebUI.Dto.ProductDtos;
using Furni.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Furni.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public AdminProductController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v = "/Admin/AdminProduct";
            ViewBag.v1 = "Ürünler";
            ViewBag.v2 = "Ürün Listesi";
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseMessage = await client.GetAsync("Product");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.v = "/Admin/AdminProduct";
            ViewBag.v1 = "Ürünler";
            ViewBag.v2 = "Ürün Ekleme";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto, IFormFile file)
        {
            var client = _httpClientFactory.CreateClient();
            if (createProductDto.file != null && createProductDto.file.Length > 0)
            {
                var fileName = Path.GetFileName(createProductDto.file.FileName);
                var filePath = Path.Combine("wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await createProductDto.file.CopyToAsync(stream);
                }
                createProductDto.ProductImage = $"/images/{fileName}";
                var jsonData = JsonConvert.SerializeObject(createProductDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri(_apiSettings.BaseUrl);
                var responseMessage = await client.PostAsync("Product", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "AdminProduct");
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            ViewBag.v = "/Admin/AdminProduct";
            ViewBag.v1 = "Ürünler";
            ViewBag.v2 = "Ürün Güncelleme";
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiSettings.BaseUrl);
            var responseMessage = await client.GetAsync("Product/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto, IFormFile file)
        {
            var client = _httpClientFactory.CreateClient();
            if (updateProductDto.file != null && updateProductDto.file.Length > 0)
            {
                var fileName = Path.GetFileName(updateProductDto.file.FileName);
                var filePath = Path.Combine("wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await updateProductDto.file.CopyToAsync(stream);
                }
                updateProductDto.ProductImage = $"/images/{fileName}";
                var jsonData = JsonConvert.SerializeObject(updateProductDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri(_apiSettings.BaseUrl);
                var responseMessage = await client.PutAsync("Product", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "AdminProduct");
                }
            }
            return View();
        }
    }
}
