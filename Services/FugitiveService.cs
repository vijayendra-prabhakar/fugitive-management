using FugitiveManagement.Data;
using FugitiveManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace FugitiveManagement.Services
{
    public class FugitiveService
    {
        private readonly ApplicationDbContextFactory _factory;

        public FugitiveService(ApplicationDbContextFactory dbContext)
        {
            _factory = dbContext;
        }

        public async Task<List<Fugitive>> GetFugitivesAsync()
        {
            using var _context = _factory.CreateDbContext();
            return await _context.Fugitives.Include(f => f.Crime).ToListAsync();
        }

        public async Task<Fugitive> GetFugitiveByIdAsync(int id)
        {
            using var _context = _factory.CreateDbContext();
            return await _context.Fugitives.FindAsync(id);
        }

        public async Task AddFugitiveAsync(Fugitive fugitive)
        {
            using var _context = _factory.CreateDbContext();
            _context.Fugitives.Add(fugitive);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateFugitiveAsync(Fugitive fugitive)
        {
            using var _context = _factory.CreateDbContext();
            _context.Entry(fugitive).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteFugitiveAsync(Fugitive fugitive)
        {
            using var _context = _factory.CreateDbContext();
            _context.Fugitives.Remove(fugitive);
            await _context.SaveChangesAsync();
        }
    }
}
