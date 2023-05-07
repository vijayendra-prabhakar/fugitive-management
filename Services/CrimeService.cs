using FugitiveManagement.Data;
using FugitiveManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace FugitiveManagement.Services
{
    public class CrimeService
    {
        private readonly ApplicationDbContextFactory _factory;

        public CrimeService(ApplicationDbContextFactory context)
        {
            _factory = context;
        }

        public async Task<List<Crime>> GetCrimesAsync()
        {
            using var _context = _factory.CreateDbContext();
            return await _context.Crimes.Where(c => c != null).ToListAsync();
        }

        public async Task<Crime> GetCrimeByIdAsync(int id)
        {
            using var _context = _factory.CreateDbContext();
            return await _context.Crimes.FindAsync(id);
        }

        public async Task AddCrimeAsync(Crime crime)
        {
            using var _context = _factory.CreateDbContext();
            _context.Crimes.Add(crime);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCrimeAsync(Crime crime)
        {
            using var _context = _factory.CreateDbContext();
            _context.Entry(crime).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCrimeAsync(Crime crime)
        {
            using var _context = _factory.CreateDbContext();
            _context.Crimes.Remove(crime);
            await _context.SaveChangesAsync();
        }
    }
}
