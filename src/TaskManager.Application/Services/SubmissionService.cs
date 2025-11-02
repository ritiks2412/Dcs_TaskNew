using TaskManager.Application.DTOs.Submission;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ISubmissionRepository _submissionRepo;
        private readonly IFormRepository _formRepo;

        public SubmissionService(ISubmissionRepository submissionRepo, IFormRepository formRepo)
        {
            _submissionRepo = submissionRepo;
            _formRepo = formRepo;
        }

        public async Task<Submission> CreateAsync(CreateSubmissionDto dto, int userId)
        {
            var form = await _formRepo.GetByIdAsync(dto.FormId);
            if (form == null) throw new Exception("Form not found!");

            var submission = new Submission
            {
                FormId = dto.FormId,
                UserId = userId,
                Answers = dto.Answers,
                Status = "Pending"
            };

            await _submissionRepo.AddAsync(submission);
            await _submissionRepo.SaveChangesAsync();

            return submission;
        }

        public async Task<List<Submission>> GetByFormIdAsync(int formId)
        {
            return await _submissionRepo.GetByFormIdAsync(formId);
        }

        public async Task<bool> UpdateStatusAsync(UpdateSubmissionStatusDto dto)
        {
            var submission = await _submissionRepo.GetByIdAsync(dto.SubmissionId);
            if (submission == null) return false;

            submission.Status = dto.Status;
            await _submissionRepo.SaveChangesAsync();
            return true;
        }

        Task<List<SubmissionDto>> ISubmissionService.GetByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        Task<List<SubmissionDto>> ISubmissionService.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
