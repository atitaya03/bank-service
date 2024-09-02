using WebApplication1.Models;

namespace WebApplication1.Data

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<History> History { get; set; }

        public DbSet<BankAccount> BankAccount { get; set; }
    }
}