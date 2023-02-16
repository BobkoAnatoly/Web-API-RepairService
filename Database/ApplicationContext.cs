using Microsoft.EntityFrameworkCore;
using RepairService.Models;

namespace RepairService.Database
{
    public class ApplicationContext :DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Document> Documents { get; set; } = null!;
        public DbSet<Worker> Workers { get; set; } = null!;
    }
}
