using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {
        private readonly IFormService _formService;

        public FormsController(IFormService formService)
        {
            _formService = formService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllForms()
        {
            var forms = await _formService.GetAllAsync();
            return Ok(forms);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetForm(int id)
        {
            var form = await _formService.GetByIdAsync(id);
            if (form == null) return NotFound();
            return Ok(form);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateForm([FromBody] CreateFormDto dto)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var form = await _formService.CreateAsync(dto, userId);
            return Ok(new { message = "Form created successfully", form });
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateForm([FromBody] UpdateFormDto dto)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var updated = await _formService.UpdateAsync(dto, userId);
            if (!updated) return Unauthorized(new { message = "You are not the creator of this form" });
            return Ok(new { message = "Form updated successfully" });
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteForm(int id)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var deleted = await _formService.DeleteAsync(id, userId);
            if (!deleted) return Unauthorized(new { message = "You can't delete this form" });
            return Ok(new { message = "Form deleted successfully" });
        }
    }
}
