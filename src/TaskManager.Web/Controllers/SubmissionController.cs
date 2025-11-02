using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TaskManager.Web.Models;
using TaskManager.Web.Services;

namespace TaskManager.Web.Controllers
{
    public class SubmissionController : Controller
    {

        private readonly ApiService _api;

        public SubmissionController(ApiService api)
        {
            _api = api;
        }

        public async Task<IActionResult> FillForm(int formId)
        {
            if (HttpContext.Session.GetString("JWTToken") == null)
                return RedirectToAction("Login", "Account");

            var response = await _api.Get($"api/forms/{formId}");
            if (!response.IsSuccessStatusCode) return RedirectToAction("Index", "Form");

            var json = await response.Content.ReadAsStringAsync();
            var form = JsonSerializer.Deserialize<FormDto>(json);

            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitForm(int formId, string answers)
        {
            if (HttpContext.Session.GetString("JWTToken") == null)
                return RedirectToAction("Login", "Account");

            var request = new CreateSubmissionDto
            {
                FormId = formId,
                Answers = answers
            };

            var response = await _api.Post("api/submissions", request);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("MySubmissions");

            ViewBag.Error = "Error submitting form";
            return RedirectToAction("FillForm", new { formId });
        }

        
        public async Task<IActionResult> MySubmissions()
        {
            if (HttpContext.Session.GetString("JWTToken") == null)
                return RedirectToAction("Login", "Account");

            var response = await _api.Get("api/submissions/my");
            if (!response.IsSuccessStatusCode) return View(new List<SubmissionDto>());

            var json = await response.Content.ReadAsStringAsync();
            var submissions = JsonSerializer.Deserialize<List<SubmissionDto>>(json);

            return View(submissions);
        }


        

        public IActionResult Index()
        {
            return View();
        }
    }
}
