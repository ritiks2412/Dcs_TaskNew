using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TaskManager.Web.Models;
using TaskManager.Web.Services;

namespace TaskManager.Web.Controllers
{
    public class FormController : Controller
    {
        private readonly ApiService _api;

        public FormController(ApiService api)
        {
            _api = api;
        }
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("JWTToken") == null)
                return RedirectToAction("Login", "Account");

            var response = await _api.Get("api/forms");

            if (!response.IsSuccessStatusCode)
                return View(new List<FormDto>());

            var result = await response.Content.ReadAsStringAsync();

            var formDtos = JsonSerializer.Deserialize<List<FormDtos>>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View(formDtos);
        }

        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("JWTToken") == null)
                return RedirectToAction("Login", "Account");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFormDto model)
        {
            var response = await _api.Post("api/forms", model);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");




            ViewBag.Error = "Failed to create form!";
            return View(model);
        }
    }
}
