using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repositories
{
    public class SubmissionRepository : ISubmissionRepository
    {
        private readonly AppDbContext _context;

        public SubmissionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Submission submission)
        {
            await _context.Submissions.AddAsync(submission);
        }

        public async Task<List<Submission>> GetByFormIdAsync(int formId)
        {
            return await _context.Submissions
                .Where(s => s.FormId == formId)
                .Include(s => s.User)
                .ToListAsync();
        }

        public async Task<Submission?> GetByIdAsync(int id)
        {
            return await _context.Submissions
                .Include(s => s.Form)
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
