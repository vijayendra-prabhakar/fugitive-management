using FugitiveManagement.Data;
using FugitiveManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace FugitiveManagement.Services
{
    public class ProsecutorService
    {
        private readonly ApplicationDbContextFactory _factory;

        public ProsecutorService(ApplicationDbContextFactory context)
        {
            _factory = context;
        }

        public async Task<List<Prosecutor>> GetProsecutorsAsync()
        {
            using var _context = _factory.CreateDbContext();
            return await _context.Prosecutors.Include(p => p.Crime).ToListAsync();
        }

        public async Task<Prosecutor> GetProsecutorByIdAsync(int id)
        {
            using var _context = _factory.CreateDbContext();
            return await _context.Prosecutors.FindAsync(id);
        }

        public async Task AddProsecutorAsync(Prosecutor prosecutor)
        {
            using var _context = _factory.CreateDbContext();
            _context.Prosecutors.Add(prosecutor);
            await _context.SaveChangesAsync();
        }

        // Prosecutor methods
        public async Task UpdateProsecutorAsync(Prosecutor prosecutor)
        {
            using var _context = _factory.CreateDbContext();
            _context.Entry(prosecutor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProsecutorAsync(Prosecutor prosecutor)
        {
            using var _context = _factory.CreateDbContext();
            _context.Prosecutors.Remove(prosecutor);
            await _context.SaveChangesAsync();
        }
    }
}
