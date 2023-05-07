using FugitiveManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace FugitiveManagement
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Fugitive> Fugitives { get; set; }
        public DbSet<Crime> Crimes { get; set; }
        public DbSet<Prosecutor> Prosecutors { get; set; }
    }
}
