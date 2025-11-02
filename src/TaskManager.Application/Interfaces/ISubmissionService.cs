using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs.Submission;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Interfaces
{
    public interface ISubmissionService
    {
        Task<Submission> CreateAsync(CreateSubmissionDto dto, int userId);
        Task<List<Submission>> GetByFormIdAsync(int formId);
        Task<bool> UpdateStatusAsync(UpdateSubmissionStatusDto dto);
    }
}
