using TaskManager.Domain.Entities;

namespace TaskManager.Application.Interfaces
{
    public interface IFormRepository
    {
        Task<List<Form>> GetAllAsync();
        Task<Form?> GetByIdAsync(int id);
        Task AddAsync(Form form);
        Task UpdateAsync(Form form);
        Task DeleteAsync(Form form);
        Task SaveChangesAsync();
    }
}
