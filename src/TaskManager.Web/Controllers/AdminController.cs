using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TaskManager.Application.DTOs.Submission;
using TaskManager.Web.Services;

namespace TaskManager.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApiService _api;

        public AdminController(ApiService api)
        {
            _api = api;
        }

        //  Fetch all submissions
        public async Task<IActionResult> AllSubmissions()
        {
            var response = await _api.Get("api/submissions/all");
            var list = new List<SubmissionDto>();

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                list = JsonSerializer.Deserialize<List<SubmissionDto>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return View(list);
        }

        //  Approve Submission
        [HttpPost]
        public async Task<IActionResult> Approve(int id)
        {
            var data = new UpdateSubmissionStatusDto
            {
                SubmissionId = id,
                Status = "Approved"
            };

            await _api.Put("api/submissions/status", data);
            return RedirectToAction("AllSubmissions");
        }

        // Reject Submission
        [HttpPost]
        public async Task<IActionResult> Reject(int id)
        {
            var data = new UpdateSubmissionStatusDto
            {
                SubmissionId = id,
                Status = "Rejected"
            };

            await _api.Put("api/submissions/status", data);
            return RedirectToAction("AllSubmissions");
        }
        public IActionResult Index()
        {
            return View(); 
        }
    }
}
