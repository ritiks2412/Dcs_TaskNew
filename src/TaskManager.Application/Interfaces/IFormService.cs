using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Interfaces
{
    public interface IFormService
    {
        Task<List<Form>> GetAllAsync();
        Task<Form?> GetByIdAsync(int id);
        Task<Form> CreateAsync(CreateFormDto dto, int userId);
        Task<bool> UpdateAsync(UpdateFormDto dto, int userId);
        Task<bool> DeleteAsync(int id, int userId);
    }
}
