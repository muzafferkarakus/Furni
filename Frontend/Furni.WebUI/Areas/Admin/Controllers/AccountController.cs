using Furni.EntityLayer.Concrete;
using Furni.WebUI.Dto.AccountDtos;
using Furni.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Furni.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly HttpClient _httpClient;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, HttpClient httpClient)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _httpClient = httpClient;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateNewUserDto createNewUserDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var appUser = new AppUser()
            {
                Name = createNewUserDto.Name,
                Surname = createNewUserDto.Surname,
                UserName = createNewUserDto.Username,
                Email = createNewUserDto.Mail,
            };
            var result = await _userManager.CreateAsync(appUser, createNewUserDto.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginUserDto.Username, loginUserDto.Password, false, false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(loginUserDto.Username);
                    var loginRequest = new
                    {
                        Username = loginUserDto.Username,
                        Password = loginUserDto.Password
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json");

                    var response = await _httpClient.PostAsync("http://localhost:5000/api/Auth/Login", content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();

                        Console.WriteLine(responseContent);

                        var loginResponse = JsonConvert.DeserializeObject<LoginResponseDto>(responseContent);
                        var token = loginResponse.Token;
                        HttpContext.Session.SetString("Token", token);

                        return RedirectToAction("Index", "AdminProduct");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Giriş başarısız.");
                    }
                }
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
