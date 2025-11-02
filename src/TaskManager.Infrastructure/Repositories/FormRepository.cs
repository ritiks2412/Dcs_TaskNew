using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repositories
{
    public class FormRepository : IFormRepository
    {
        private readonly AppDbContext _context;

        public FormRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Form>> GetAllAsync() =>
            await _context.Forms.Include(f => f.CreatedByUser).ToListAsync();

        public async Task<Form?> GetByIdAsync(int id) =>
            await _context.Forms.Include(f => f.CreatedByUser).FirstOrDefaultAsync(x => x.Id == id);

        public async Task AddAsync(Form form) => await _context.Forms.AddAsync(form);

        public async Task UpdateAsync(Form form) =>  _context.Forms.Update(form);

        public async Task DeleteAsync(Form form) => _context.Forms.Remove(form);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

    }
}
