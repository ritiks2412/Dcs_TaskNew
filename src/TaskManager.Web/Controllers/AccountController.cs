using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TaskManager.Web.Models;
using TaskManager.Web.Services;

namespace TaskManager.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApiService _api;

        public AccountController(ApiService api)
        {
            _api = api;
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
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Invalid credentials";
                return View();
            }

            var result = await response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<JsonElement>(result);
            var token = json.GetProperty("accessToken").GetString();

            HttpContext.Session.SetString("JWTToken", token);
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
