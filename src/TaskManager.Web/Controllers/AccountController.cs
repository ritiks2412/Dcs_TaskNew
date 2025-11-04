using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TaskManager.Web.Models;
using TaskManager.Web.Services;

namespace TaskManager.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApiService _api;
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(ApiService api, HttpClient client, IHttpContextAccessor httpContextAccessor)
        {
            _api = api;
            _client = client;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login() => View();



        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var response = await _api.Post("api/auth/login", request);

            //var token = _httpContextAccessor.HttpContext.Session.GetString("JWTToken");


            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Invalid credentials";
                return View();
            }

            var result = await response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<JsonElement>(result);
            var token = json.GetProperty("accessToken").GetString();

            _httpContextAccessor.HttpContext.Session.SetString("JWTToken", token);


            var getToken = _httpContextAccessor.HttpContext.Session.GetString("JWTToken");

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var response = await _api.Post("api/auth/register", request);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Login");

            ViewBag.Error = "Failed to register!";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}
