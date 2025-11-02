using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManager.Application.DTOs.Submission;
using TaskManager.Application.Interfaces;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionsController : ControllerBase
    {
        private readonly ISubmissionService _submissionService;

        public SubmissionsController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }
        //Submit a form (Only logged-in users can submit)
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SubmitForm([FromBody] CreateSubmissionDto dto)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var submission = await _submissionService.CreateAsync(dto, userId);
            return Ok(new { message = "Form submitted successfully!", submission });
        }

        // Get submissions for a specific form (Only admin or creator)
        [Authorize]
        [HttpGet("form/{formId}")]
        public async Task<IActionResult> GetSubmissionsByForm(int formId)
        {
            var submissions = await _submissionService.GetByFormIdAsync(formId);
            return Ok(submissions);
        }

        // Update submission status (Admin only: Approve / Reject)

        [Authorize(Roles = "Admin")]
        [HttpPut("status")]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateSubmissionStatusDto dto)
        {
            var result = await _submissionService.UpdateStatusAsync(dto);
            if (!result) return NotFound(new { message = "Submission not found!" });

            return Ok(new { message = $"Submission status updated to {dto.Status}" });
        }

    }
}
