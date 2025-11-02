using TaskManager.Domain.Entities;

namespace TaskManager.Application.Interfaces
{
    public interface ISubmissionRepository
    {
        Task AddAsync(Submission submission);
        Task<List<Submission>> GetByFormIdAsync(int formId);
        Task<Submission?> GetByIdAsync(int id);
        Task SaveChangesAsync();
        Task<List<Submission>> GetByUserIdAsync(int userId);
        Task<List<Submission>> GetAllAsync();


    }
}
