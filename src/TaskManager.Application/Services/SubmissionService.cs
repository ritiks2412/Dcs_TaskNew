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

        public async Task<List<SubmissionDto>> GetByUserIdAsync(int userId)
        {
            var submissions = await _submissionRepo.GetByUserIdAsync(userId);

            return submissions.Select(s => new SubmissionDto
            {
                Id = s.Id,
                FormId = s.FormId,
                FormTitle = s.Form?.Title ?? "",
                Answers = s.Answers,
                Status = s.Status,
                CreatedAt = s.CreatedAt
            }).ToList();
        }

        public async Task<List<SubmissionDto>> GetAllAsync()
        {
            var submissions = await _submissionRepo.GetAllAsync();

            return submissions.Select(s => new SubmissionDto
            {
                Id = s.Id,
                FormId = s.FormId,
                FormTitle = s.Form?.Title ?? "",
                Answers = s.Answers,
                Status = s.Status,
                CreatedAt = s.CreatedAt
            }).ToList();
        }



    }
}
