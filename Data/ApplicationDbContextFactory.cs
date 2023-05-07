using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FugitiveManagement.Data
{
    public class ApplicationDbContextFactory
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;
        private readonly IConfiguration _configuration;

        public ApplicationDbContextFactory(IOptions<DbContextOptions<ApplicationDbContext>> optionsAccessor, IConfiguration configuration)
        {
            _options = optionsAccessor.Value;
            _configuration = configuration;
        }

        public ApplicationDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
