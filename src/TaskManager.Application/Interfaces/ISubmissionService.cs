using TaskManager.Application.DTOs.Submission;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Interfaces
{
    public interface ISubmissionService
    {
        Task<Submission> CreateAsync(CreateSubmissionDto dto, int userId);
        Task<List<Submission>> GetByFormIdAsync(int formId);
        Task<bool> UpdateStatusAsync(UpdateSubmissionStatusDto dto);

        Task<List<SubmissionDto>> GetByUserIdAsync(int userId);
        Task<List<SubmissionDto>> GetAllAsync();

        //Task<DashboardStatsDto> GetDashboardStatsAsync();


    }
}
