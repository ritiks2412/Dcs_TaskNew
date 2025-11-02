using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services
{
    public class FormService : IFormService
    {
        private readonly IFormRepository _formRepo;

        public FormService(IFormRepository formRepo)
        {
            _formRepo = formRepo;
        }
        public async Task<List<Form>> GetAllAsync() => await _formRepo.GetAllAsync();

        public async Task<Form?> GetByIdAsync(int id) => await _formRepo.GetByIdAsync(id);
        public async Task<Form> CreateAsync(CreateFormDto dto, int userId)
        {
            var form = new Form
            {
                Title = dto.Title,
                Description = dto.Description,
                Fields = dto.Fields,
                CreatedBy = userId
            };
            await _formRepo.AddAsync(form);
            await _formRepo.SaveChangesAsync();
            return form;
        }

        public async Task<bool> UpdateAsync(UpdateFormDto dto, int userId)
        {
            var form = await _formRepo.GetByIdAsync(dto.Id);
            if (form == null || form.CreatedBy != userId) return false;

            form.Title = dto.Title;
            form.Description = dto.Description;
            form.Fields = dto.Fields;
            form.IsActive = dto.IsActive;

            await _formRepo.UpdateAsync(form);
            await _formRepo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id, int userId)
        {
            var form = await _formRepo.GetByIdAsync(id);
            if (form == null || form.CreatedBy != userId) return false;

            await _formRepo.DeleteAsync(form);
            await _formRepo.SaveChangesAsync();
            return true;
        }
    }
}
